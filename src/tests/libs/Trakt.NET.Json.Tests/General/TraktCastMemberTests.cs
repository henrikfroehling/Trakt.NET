namespace TraktNET.Json.General
{
    public sealed class TraktCastMemberTests
    {
        [Fact]
        public void TestTraktCastMemberConstructor()
        {
            var castMember = new TraktCastMember();

            castMember.Characters.ShouldBeNull();
            castMember.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCastMemberFromJson()
        {
            TraktCastMember? castMember = await TraktTestUtility.DeserializeJsonAsync<TraktCastMember>("General\\castmember.json");

            castMember.ShouldNotBeNull();

            castMember!.Characters.ShouldNotBeNull();
            castMember!.Characters!.Count.ShouldBe(2);
            castMember!.Characters!.ShouldBe(["Peter Quill", "Star-Lord"], Case.Sensitive);
            castMember!.Person.ShouldNotBeNull();
            castMember!.Person!.Name.ShouldBe("Chris Pratt");
            castMember!.Person!.IDs.ShouldNotBeNull();
            castMember!.Person!.IDs!.Trakt.ShouldBe(422885U);
            castMember!.Person!.IDs!.Slug.ShouldBe("chris-pratt");
            castMember!.Person!.IDs!.IMDB.ShouldBe("nm0695435");
            castMember!.Person!.IDs!.TMDB.ShouldBe(73457U);
        }
    }
}
