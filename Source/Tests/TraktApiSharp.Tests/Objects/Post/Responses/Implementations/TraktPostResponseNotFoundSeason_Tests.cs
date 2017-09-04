namespace TraktApiSharp.Tests.Objects.Post.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundSeason_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundSeason_Implements_ITraktPostResponseNotFoundSeason_Interface()
        {
            typeof(TraktPostResponseNotFoundSeason).GetInterfaces().Should().Contain(typeof(ITraktPostResponseNotFoundSeason));
        }

        [Fact]
        public void Test_TraktPostResponseNotFoundSeason_Default_Constructor()
        {
            var postResponseNotFoundSeason = new TraktPostResponseNotFoundSeason();

            postResponseNotFoundSeason.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundSeason_From_Json()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();
            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(JSON) as TraktPostResponseNotFoundSeason;

            postResponseNotFoundSeason.Should().NotBeNull();
            postResponseNotFoundSeason.Ids.Should().NotBeNull();
            postResponseNotFoundSeason.Ids.Trakt.Should().Be(61430U);
            postResponseNotFoundSeason.Ids.Tvdb.Should().Be(279121U);
            postResponseNotFoundSeason.Ids.Tmdb.Should().Be(60523U);
            postResponseNotFoundSeason.Ids.TvRage.Should().Be(36939U);
        }

        private const string JSON =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";
    }
}
