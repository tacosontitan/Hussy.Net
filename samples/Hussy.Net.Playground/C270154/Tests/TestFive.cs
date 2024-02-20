namespace Hussy.Net.Playground;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseFive_Passes()
    {
        var length = 3;
        var characters = "CODEGLF";
        var expectedResult = new[]
        {
            "COC", "COD", "COE", "COG", "COL", "COF", "CDC", "CDO", "CDE", "CDG", "CDL", "CDF", "CEC", "CEO", "CED",
            "CEG", "CEL", "CEF", "CGC", "CGO", "CGD", "CGE", "CGL", "CGF", "CLC", "CLO", "CLD", "CLE", "CLG", "CLF",
            "CFC", "CFO", "CFD", "CFE", "CFG", "CFL", "OCO", "OCD", "OCE", "OCG", "OCL", "OCF", "ODC", "ODO", "ODE",
            "ODG", "ODL", "ODF", "OEC", "OEO", "OED", "OEG", "OEL", "OEF", "OGC", "OGO", "OGD", "OGE", "OGL", "OGF",
            "OLC", "OLO", "OLD", "OLE", "OLG", "OLF", "OFC", "OFO", "OFD", "OFE", "OFG", "OFL", "DCO", "DCD", "DCE",
            "DCG", "DCL", "DCF", "DOC", "DOD", "DOE", "DOG", "DOL", "DOF", "DEC", "DEO", "DED", "DEG", "DEL", "DEF",
            "DGC", "DGO", "DGD", "DGE", "DGL", "DGF", "DLC", "DLO", "DLD", "DLE", "DLG", "DLF", "DFC", "DFO", "DFD",
            "DFE", "DFG", "DFL", "ECO", "ECD", "ECE", "ECG", "ECL", "ECF", "EOC", "EOD", "EOE", "EOG", "EOL", "EOF",
            "EDC", "EDO", "EDE", "EDG", "EDL", "EDF", "EGC", "EGO", "EGD", "EGE", "EGL", "EGF", "ELC", "ELO", "ELD",
            "ELE", "ELG", "ELF", "EFC", "EFO", "EFD", "EFE", "EFG", "EFL", "GCO", "GCD", "GCE", "GCG", "GCL", "GCF",
            "GOC", "GOD", "GOE", "GOG", "GOL", "GOF", "GDC", "GDO", "GDE", "GDG", "GDL", "GDF", "GEC", "GEO", "GED",
            "GEG", "GEL", "GEF", "GLC", "GLO", "GLD", "GLE", "GLG", "GLF", "GFC", "GFO", "GFD", "GFE", "GFG", "GFL",
            "LCO", "LCD", "LCE", "LCG", "LCL", "LCF", "LOC", "LOD", "LOE", "LOG", "LOL", "LOF", "LDC", "LDO", "LDE",
            "LDG", "LDL", "LDF", "LEC", "LEO", "LED", "LEG", "LEL", "LEF", "LGC", "LGO", "LGD", "LGE", "LGL", "LGF",
            "LFC", "LFO", "LFD", "LFE", "LFG", "LFL", "FCO", "FCD", "FCE", "FCG", "FCL", "FCF", "FOC", "FOD", "FOE",
            "FOG", "FOL", "FOF", "FDC", "FDO", "FDE", "FDG", "FDL", "FDF", "FEC", "FEO", "FED", "FEG", "FEL", "FEF",
            "FGC", "FGO", "FGD", "FGE", "FGL", "FGF", "FLC", "FLO", "FLD", "FLE", "FLG", "FLF"
        };

        RunTest(expectedResult, characters, length);
    }
}