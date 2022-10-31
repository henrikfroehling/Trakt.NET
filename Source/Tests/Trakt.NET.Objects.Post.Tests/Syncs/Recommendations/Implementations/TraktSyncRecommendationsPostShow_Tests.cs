namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Implementations")]
    public class  TraktSyncRecommendationsPostShow_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsPostShow_Default_Constructor()
        {
            var syncRecommendationsPostShow = new TraktSyncRecommendationsPostShow();

            syncRecommendationsPostShow.Title.Should().BeNull();
            syncRecommendationsPostShow.Year.Should().BeNull();
            syncRecommendationsPostShow.Ids.Should().BeNull();
            syncRecommendationsPostShow.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsPostShow_From_Json()
        {
            var jsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            var syncRecommendationsPostShow = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsPostShow;

            syncRecommendationsPostShow.Should().NotBeNull();

            syncRecommendationsPostShow.Title.Should().Be("Breaking Bad");
            syncRecommendationsPostShow.Year.Should().Be(2008);
            syncRecommendationsPostShow.Ids.Should().NotBeNull();
            syncRecommendationsPostShow.Ids.Trakt.Should().Be(1U);
            syncRecommendationsPostShow.Ids.Slug.Should().Be("breaking-bad");
            syncRecommendationsPostShow.Ids.Tvdb.Should().Be(81189U);
            syncRecommendationsPostShow.Ids.Imdb.Should().Be("tt0903747");
            syncRecommendationsPostShow.Ids.Tmdb.Should().Be(1396U);
            syncRecommendationsPostShow.Notes.Should().Be("I AM THE DANGER!");
        }

        private const string JSON =
            @"{
                ""title"": ""Breaking Bad"",
                ""year"": 2008,
                ""ids"": {
                  ""trakt"": 1,
                  ""slug"": ""breaking-bad"",
                  ""tvdb"": 81189,
                  ""imdb"": ""tt0903747"",
                  ""tmdb"": 1396
                },
                ""notes"": ""I AM THE DANGER!""
              }";
    }
}
