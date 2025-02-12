namespace TraktNET.Json.General
{
    public sealed class TraktCrewMemberTests
    {
        [Fact]
        public void TestTraktCrewMemberConstructor()
        {
            var crewMember = new TraktCrewMember();

            crewMember.Jobs.ShouldBeNull();
            crewMember.Person.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCrewMemberFromJson()
        {
            TraktCrewMember? crewMember = await TraktTestUtility.DeserializeJsonAsync<TraktCrewMember>("General\\crewmember.json");

            crewMember.ShouldNotBeNull();

            crewMember!.Jobs.ShouldNotBeNull();
            crewMember!.Jobs!.Count.ShouldBe(1);
            crewMember!.Jobs!.ShouldBe(["Original Music Composer"], Case.Sensitive);

            crewMember!.Person.ShouldNotBeNull();
            crewMember!.Person!.Name.ShouldBe("John Murphy");
            crewMember!.Person!.IDs.ShouldNotBeNull();
            crewMember!.Person!.IDs!.Trakt.ShouldBe(1005U);
            crewMember!.Person!.IDs!.Slug.ShouldBe("john-murphy");
            crewMember!.Person!.IDs!.IMDB.ShouldBe("nm0614373");
            crewMember!.Person!.IDs!.TMDB.ShouldBe(960U);
        }
    }
}
