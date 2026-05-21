[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter()]
    [string]$Token = $env:GITHUB_TOKEN,

    [Parameter()]
    [string]$Owner = 'tacosontitan',

    [Parameter()]
    [string]$Repository = 'Hussy.Net',

    [Parameter()]
    [int]$ParentIssueNumber = 96,

    [Parameter()]
    [switch]$IncludeCheckedFeatures
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($Token)) {
    throw 'Provide a GitHub token with the `repo` scope using -Token or the GITHUB_TOKEN environment variable.'
}

$headers = @{
    Accept        = 'application/vnd.github+json'
    'X-GitHub-Api-Version' = '2022-11-28'
}

$authHeaders = @(
    "Bearer $Token",
    "token $Token"
)

$baseUri = "https://api.github.com/repos/$Owner/$Repository"
$parentIssueUri = "$baseUri/issues/$ParentIssueNumber"

function Invoke-GitHubApi {
    param(
        [Parameter(Mandatory)]
        [ValidateSet('Get', 'Post')]
        [string]$Method,

        [Parameter(Mandatory)]
        [string]$Uri,

        [Parameter()]
        [string]$Body,

        [Parameter()]
        [string]$ContentType
    )

    foreach ($authHeader in $authHeaders) {
        $requestHeaders = $headers.Clone()
        $requestHeaders.Authorization = $authHeader

        try {
            if ($Method -eq 'Post') {
                return Invoke-RestMethod -Method $Method -Uri $Uri -Headers $requestHeaders -Body $Body -ContentType $ContentType
            }

            return Invoke-RestMethod -Method $Method -Uri $Uri -Headers $requestHeaders
        }
        catch {
            $statusCode = $_.Exception.Response.StatusCode.value__
            if ($statusCode -ne 401) {
                throw
            }
        }
    }

    throw 'Authentication failed. Ensure your token is valid and has repository issue permissions.'
}

Write-Host "Loading issue #$ParentIssueNumber from $Owner/$Repository..."
$parentIssue = Invoke-GitHubApi -Method Get -Uri $parentIssueUri

if (-not $parentIssue.body) {
    throw "Issue #$ParentIssueNumber has no body content to parse."
}

$requirements = @(
    '- [ ] Default Implementation'
    '- [ ] XML Documentation'
    '- [ ] Unit Test Coverage'
    '- [ ] Code Analysis (Common Use Cases)'
)

function New-IssueTitle {
    param(
        [Parameter(Mandatory)]
        [string]$Feature,

        [Parameter(Mandatory)]
        [ValidateSet('implementation', 'sunset')]
        [string]$Category
    )

    if ($Category -eq 'sunset') {
        return "Initial Release: Evaluate sunsetting of $Feature"
    }

    return "Initial Release: Implement $Feature"
}

function New-IssueBody {
    param(
        [Parameter(Mandatory)]
        [string]$Feature,

        [Parameter(Mandatory)]
        [ValidateSet('implementation', 'sunset')]
        [string]$Category,

        [Parameter(Mandatory)]
        [int]$ParentIssue
    )

    if ($Category -eq 'sunset') {
        return @"
### Summary
Investigate whether `$Feature` should be kept or sunset as part of #$ParentIssue.

### Investigation Checklist
- [ ] Evaluate current and expected usage
- [ ] Assess maintenance cost and value
- [ ] Decide to keep or sunset
- [ ] Document final decision and rationale
"@
    }

    $requirementsBlock = $requirements -join [Environment]::NewLine

    return @"
### Summary
Implement `$Feature` as part of #$ParentIssue.

### Requirements
$requirementsBlock
"@
}

$allIssues = [System.Collections.Generic.List[object]]::new()
$page = 1

while ($true) {
    $issuesPageUri = "$baseUri/issues?state=all&per_page=100&page=$page"
    $issuesPage = Invoke-GitHubApi -Method Get -Uri $issuesPageUri

    if (-not $issuesPage -or $issuesPage.Count -eq 0) {
        break
    }

    foreach ($issue in $issuesPage) {
        # Only include issues (pull requests contain the pull_request property).
        if (-not $issue.pull_request) {
            [void]$allIssues.Add($issue)
        }
    }

    if ($issuesPage.Count -lt 100) {
        break
    }

    $page++
}

$existingTitles = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
foreach ($issue in $allIssues) {
    if ($issue.title) {
        [void]$existingTitles.Add($issue.title)
    }
}

$featuresToCreate = [System.Collections.Generic.List[object]]::new()
$currentCategory = 'implementation'
$lines = $parentIssue.body -split '\r?\n'

foreach ($line in $lines) {
    if ($line -match 'need to be evaluated for potential sunsetting') {
        $currentCategory = 'sunset'
        continue
    }

    if ($line -match '^\s*-\s*\[(?<state>[xX ])\]\s*(?<feature>.+)\s*$') {
        $state = $matches.state
        $feature = $matches.feature.Trim()

        if (-not $IncludeCheckedFeatures -and $state -match '[xX]') {
            continue
        }

        $title = New-IssueTitle -Feature $feature -Category $currentCategory
        $body = New-IssueBody -Feature $feature -Category $currentCategory -ParentIssue $ParentIssueNumber

        $featuresToCreate.Add([pscustomobject]@{
            Feature  = $feature
            Category = $currentCategory
            Title    = $title
            Body     = $body
        })
    }
}

if ($featuresToCreate.Count -eq 0) {
    Write-Host 'No features were found to create issues for.'
    exit 0
}

Write-Host "Found $($featuresToCreate.Count) feature issue(s) to evaluate for creation."

$created = 0
$skipped = 0

foreach ($item in $featuresToCreate) {
    if ($existingTitles.Contains($item.Title)) {
        Write-Host "Skipping existing issue: $($item.Title)"
        $skipped++
        continue
    }

    $payload = @{
        title = $item.Title
        body  = $item.Body
    } | ConvertTo-Json -Depth 5

    if ($PSCmdlet.ShouldProcess($item.Title, 'Create GitHub issue')) {
        $createdIssue = Invoke-GitHubApi -Method Post -Uri "$baseUri/issues" -Body $payload -ContentType 'application/json'
        Write-Host "Created #$($createdIssue.number): $($createdIssue.title)"
        [void]$existingTitles.Add($item.Title)
        $created++
    }
}

Write-Host "Done. Created: $created, Skipped: $skipped"
