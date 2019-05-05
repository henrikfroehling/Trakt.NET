namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCastMember_Tests
    {
        [Fact]
        public void Test_TraktCastMember_Default_Constructor()
        {
            var traktCastMember = new TraktCastMember();

            traktCastMember.Character.Should().BeNull();
            traktCastMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCastMember_From_Json()
        {
            var jsonReader = new CastMemberObjectJsonReader();
            var traktCastMember = await jsonReader.ReadObjectAsync(JSON) as TraktCastMember;

            traktCastMember.Should().NotBeNull();
            traktCastMember.Character.Should().Be("Joe Brody");
            traktCastMember.Person.Should().NotBeNull();
            traktCastMember.Person.Name.Should().Be("Bryan Cranston");
            traktCastMember.Person.Ids.Should().NotBeNull();
            traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        private const string JSON =
            @"{
                ""character"": ""Joe Brody"",
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
