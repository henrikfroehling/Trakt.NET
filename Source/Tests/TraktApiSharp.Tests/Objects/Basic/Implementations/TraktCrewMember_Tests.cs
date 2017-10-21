namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCrewMember_Tests
    {
        [Fact]
        public void Test_TraktCrewMember_Default_Constructor()
        {
            var traktCrewMember = new TraktCrewMember();

            traktCrewMember.Job.Should().BeNull();
            traktCrewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCrewMember_From_Json()
        {
            var jsonReader = new CrewMemberObjectJsonReader();
            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON) as TraktCrewMember;

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().Be("Director");
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
                ""job"": ""Director"",
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
