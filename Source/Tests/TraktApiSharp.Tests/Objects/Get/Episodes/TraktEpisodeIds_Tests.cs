namespace TraktApiSharp.Tests.Objects.Get.Episodes
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.JsonReader.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes")]
    public class TraktEpisodeIds_Tests
    {
        [Fact]
        public void Test_TraktEpisodeIds_Default_Constructor()
        {
            var episodeIds = new TraktEpisodeIds();

            episodeIds.Trakt.Should().Be(0);
            episodeIds.Tvdb.Should().BeNull();
            episodeIds.Imdb.Should().BeNullOrEmpty();
            episodeIds.Tmdb.Should().BeNull();
            episodeIds.TvRage.Should().BeNull();
            episodeIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeIds_HasAnyId()
        {
            var episodeIds = new TraktEpisodeIds { Trakt = 1 };
            episodeIds.HasAnyId.Should().BeTrue();

            episodeIds = new TraktEpisodeIds { Tvdb = 1 };
            episodeIds.HasAnyId.Should().BeTrue();

            episodeIds = new TraktEpisodeIds { Imdb = "imdb" };
            episodeIds.HasAnyId.Should().BeTrue();

            episodeIds = new TraktEpisodeIds { Tmdb = 1 };
            episodeIds.HasAnyId.Should().BeTrue();

            episodeIds = new TraktEpisodeIds { TvRage = 1 };
            episodeIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeIds_GetBestId()
        {
            var episodeIds = new TraktEpisodeIds();

            var bestId = episodeIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            episodeIds = new TraktEpisodeIds { Trakt = 1 };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds { Tvdb = 1 };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds { Imdb = "imdb" };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("imdb");

            episodeIds = new TraktEpisodeIds { Tmdb = 1 };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds { TvRage = 1 };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds
            {
                Trakt = 1,
                Tvdb = 1,
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds
            {
                Tvdb = 1,
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");

            episodeIds = new TraktEpisodeIds
            {
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("imdb");

            episodeIds = new TraktEpisodeIds
            {
                Tmdb = 1,
                TvRage = 1
            };

            bestId = episodeIds.GetBestId();
            bestId.Should().Be("1");
        }

        [Fact]
        public void Test_TraktEpisodeIds_From_Json()
        {
            var jsonReader = new TraktEpisodeIdsObjectJsonReader();
            var episodeIds = jsonReader.ReadObject(JSON);

            episodeIds.Should().NotBeNull();
            episodeIds.Trakt.Should().Be(73640);
            episodeIds.Tvdb.Should().Be(3254641U);
            episodeIds.Imdb.Should().Be("tt1480055");
            episodeIds.Tmdb.Should().Be(63056U);
            episodeIds.TvRage.Should().Be(1065008299U);
            episodeIds.HasAnyId.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";
    }
}
