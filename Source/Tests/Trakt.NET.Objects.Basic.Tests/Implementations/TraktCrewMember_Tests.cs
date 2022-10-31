namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktCrewMember_Tests
    {
        [Fact]
        public void Test_TraktCrewMember_Default_Constructor()
        {
            var traktCrewMember = new TraktCrewMember();

            traktCrewMember.Jobs.Should().BeNull();
            traktCrewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCrewMember_From_Json()
        {
            var jsonReader = new CrewMemberObjectJsonReader();
            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON) as TraktCrewMember;

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            traktCrewMember.Person.Should().NotBeNull();
            traktCrewMember.Person.Name.Should().Be("Bryan Cranston");
            traktCrewMember.Person.Ids.Should().NotBeNull();
            traktCrewMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCrewMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCrewMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCrewMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCrewMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        private const string JSON =
            @"{
                ""jobs"": [
                  ""Director""
                ],
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";
    }
}
