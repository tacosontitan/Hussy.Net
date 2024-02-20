namespace Hussy.Net.Playground;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseSix_Passes()
    {
        var length = 4;
        var characters = "NFKD";
        var expectedResult = new[]
        {
            "NFNF", "NFNK", "NFND", "NFKN", "NFKF", "NFKD", "NFDN", "NFDF", "NFDK", "NKNF", "NKNK", "NKND", "NKFN",
            "NKFK", "NKFD", "NKDN", "NKDF", "NKDK", "NDNF", "NDNK", "NDND", "NDFN", "NDFK", "NDFD", "NDKN", "NDKF",
            "NDKD", "FNFN", "FNFK", "FNFD", "FNKN", "FNKF", "FNKD", "FNDN", "FNDF", "FNDK", "FKNF", "FKNK", "FKND",
            "FKFN", "FKFK", "FKFD", "FKDN", "FKDF", "FKDK", "FDNF", "FDNK", "FDND", "FDFN", "FDFK", "FDFD", "FDKN",
            "FDKF", "FDKD", "KNFN", "KNFK", "KNFD", "KNKN", "KNKF", "KNKD", "KNDN", "KNDF", "KNDK", "KFNF", "KFNK",
            "KFND", "KFKN", "KFKF", "KFKD", "KFDN", "KFDF", "KFDK", "KDNF", "KDNK", "KDND", "KDFN", "KDFK", "KDFD",
            "KDKN", "KDKF", "KDKD", "DNFN", "DNFK", "DNFD", "DNKN", "DNKF", "DNKD", "DNDN", "DNDF", "DNDK", "DFNF",
            "DFNK", "DFND", "DFKN", "DFKF", "DFKD", "DFDN", "DFDF", "DFDK", "DKNF", "DKNK", "DKND", "DKFN", "DKFK",
            "DKFD", "DKDN", "DKDF", "DKDK"
        };

        RunTest(expectedResult, characters, length);
    }
}