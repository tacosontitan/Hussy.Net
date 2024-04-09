namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseSeven_Passes()
    {
        var length = 5;
        var characters = "JOHN";
        var expectedResult = new[]
        {
            "JOJOJ", "JOJOH", "JOJON", "JOJHJ", "JOJHO", "JOJHN", "JOJNJ", "JOJNO", "JOJNH", "JOHJO", "JOHJH", "JOHJN",
            "JOHOJ", "JOHOH", "JOHON", "JOHNJ", "JOHNO", "JOHNH", "JONJO", "JONJH", "JONJN", "JONOJ", "JONOH", "JONON",
            "JONHJ", "JONHO", "JONHN", "JHJOJ", "JHJOH", "JHJON", "JHJHJ", "JHJHO", "JHJHN", "JHJNJ", "JHJNO", "JHJNH",
            "JHOJO", "JHOJH", "JHOJN", "JHOHJ", "JHOHO", "JHOHN", "JHONJ", "JHONO", "JHONH", "JHNJO", "JHNJH", "JHNJN",
            "JHNOJ", "JHNOH", "JHNON", "JHNHJ", "JHNHO", "JHNHN", "JNJOJ", "JNJOH", "JNJON", "JNJHJ", "JNJHO", "JNJHN",
            "JNJNJ", "JNJNO", "JNJNH", "JNOJO", "JNOJH", "JNOJN", "JNOHJ", "JNOHO", "JNOHN", "JNONJ", "JNONO", "JNONH",
            "JNHJO", "JNHJH", "JNHJN", "JNHOJ", "JNHOH", "JNHON", "JNHNJ", "JNHNO", "JNHNH", "OJOJO", "OJOJH", "OJOJN",
            "OJOHJ", "OJOHO", "OJOHN", "OJONJ", "OJONO", "OJONH", "OJHJO", "OJHJH", "OJHJN", "OJHOJ", "OJHOH", "OJHON",
            "OJHNJ", "OJHNO", "OJHNH", "OJNJO", "OJNJH", "OJNJN", "OJNOJ", "OJNOH", "OJNON", "OJNHJ", "OJNHO", "OJNHN",
            "OHJOJ", "OHJOH", "OHJON", "OHJHJ", "OHJHO", "OHJHN", "OHJNJ", "OHJNO", "OHJNH", "OHOJO", "OHOJH", "OHOJN",
            "OHOHJ", "OHOHO", "OHOHN", "OHONJ", "OHONO", "OHONH", "OHNJO", "OHNJH", "OHNJN", "OHNOJ", "OHNOH", "OHNON",
            "OHNHJ", "OHNHO", "OHNHN", "ONJOJ", "ONJOH", "ONJON", "ONJHJ", "ONJHO", "ONJHN", "ONJNJ", "ONJNO", "ONJNH",
            "ONOJO", "ONOJH", "ONOJN", "ONOHJ", "ONOHO", "ONOHN", "ONONJ", "ONONO", "ONONH", "ONHJO", "ONHJH", "ONHJN",
            "ONHOJ", "ONHOH", "ONHON", "ONHNJ", "ONHNO", "ONHNH", "HJOJO", "HJOJH", "HJOJN", "HJOHJ", "HJOHO", "HJOHN",
            "HJONJ", "HJONO", "HJONH", "HJHJO", "HJHJH", "HJHJN", "HJHOJ", "HJHOH", "HJHON", "HJHNJ", "HJHNO", "HJHNH",
            "HJNJO", "HJNJH", "HJNJN", "HJNOJ", "HJNOH", "HJNON", "HJNHJ", "HJNHO", "HJNHN", "HOJOJ", "HOJOH", "HOJON",
            "HOJHJ", "HOJHO", "HOJHN", "HOJNJ", "HOJNO", "HOJNH", "HOHJO", "HOHJH", "HOHJN", "HOHOJ", "HOHOH", "HOHON",
            "HOHNJ", "HOHNO", "HOHNH", "HONJO", "HONJH", "HONJN", "HONOJ", "HONOH", "HONON", "HONHJ", "HONHO", "HONHN",
            "HNJOJ", "HNJOH", "HNJON", "HNJHJ", "HNJHO", "HNJHN", "HNJNJ", "HNJNO", "HNJNH", "HNOJO", "HNOJH", "HNOJN",
            "HNOHJ", "HNOHO", "HNOHN", "HNONJ", "HNONO", "HNONH", "HNHJO", "HNHJH", "HNHJN", "HNHOJ", "HNHOH", "HNHON",
            "HNHNJ", "HNHNO", "HNHNH", "NJOJO", "NJOJH", "NJOJN", "NJOHJ", "NJOHO", "NJOHN", "NJONJ", "NJONO", "NJONH",
            "NJHJO", "NJHJH", "NJHJN", "NJHOJ", "NJHOH", "NJHON", "NJHNJ", "NJHNO", "NJHNH", "NJNJO", "NJNJH", "NJNJN",
            "NJNOJ", "NJNOH", "NJNON", "NJNHJ", "NJNHO", "NJNHN", "NOJOJ", "NOJOH", "NOJON", "NOJHJ", "NOJHO", "NOJHN",
            "NOJNJ", "NOJNO", "NOJNH", "NOHJO", "NOHJH", "NOHJN", "NOHOJ", "NOHOH", "NOHON", "NOHNJ", "NOHNO", "NOHNH",
            "NONJO", "NONJH", "NONJN", "NONOJ", "NONOH", "NONON", "NONHJ", "NONHO", "NONHN", "NHJOJ", "NHJOH", "NHJON",
            "NHJHJ", "NHJHO", "NHJHN", "NHJNJ", "NHJNO", "NHJNH", "NHOJO", "NHOJH", "NHOJN", "NHOHJ", "NHOHO", "NHOHN",
            "NHONJ", "NHONO", "NHONH", "NHNJO", "NHNJH", "NHNJN", "NHNOJ", "NHNOH", "NHNON", "NHNHJ", "NHNHO", "NHNHN"
        };

        RunTest(expectedResult, characters, length);
    }
}