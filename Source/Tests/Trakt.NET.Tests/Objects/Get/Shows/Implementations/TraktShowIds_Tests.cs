namespace TraktNet.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowIds_Tests
    {
        [Fact]
        public void Test_TraktShowIds_Default_Constructor()
        {
            var showIds = new TraktShowIds();

            showIds.Trakt.Should().Be(0);
            showIds.Slug.Should().BeNullOrEmpty();
            showIds.Tvdb.Should().BeNull();
            showIds.Imdb.Should().BeNullOrEmpty();
            showIds.Tmdb.Should().BeNull();
            showIds.TvRage.Should().BeNull();
            showIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowIds_HasAnyId()
        {
            var showIds = new TraktShowIds { Trakt = 1 };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktShowIds { Slug = "slug" };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktShowIds { Tvdb = 1 };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktShowIds { Imdb = "imdb" };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktShowIds { Tmdb = 1 };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktShowIds { TvRage = 1 };
            showIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowIds_GetBestId()
        {
            var showIds = new TraktShowIds();

            var bestId = showIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            showIds = new TraktShowIds { Trakt = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds { Slug = "slug" };

            bestId = showIds.GetBestId();
            bestId.Should().Be("slug");

            showIds = new TraktShowIds { Tvdb = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds { Imdb = "imdb" };

            bestId = showIds.GetBestId();
            bestId.Should().Be("imdb");

            showIds = new TraktShowIds { Tmdb = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds { TvRage = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds
            {
                Trakt = 1,
                Slug = "slug",
                Tvdb = 1,
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds
            {
                Slug = "slug",
                Tvdb = 1,
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("slug");

            showIds = new TraktShowIds
            {
                Tvdb = 1,
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktShowIds
            {
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("imdb");

            showIds = new TraktShowIds
            {
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");
        }

        [Fact]
        public async Task Test_TraktShowIds_From_Json()
        {
            var jsonReader = new ShowIdsObjectJsonReader();
            var showIds = await jsonReader.ReadObjectAsync(JSON) as TraktShowIds;

            showIds.Should().NotBeNull();
            showIds.Trakt.Should().Be(1390);
            showIds.Slug.Should().Be("game-of-thrones");
            showIds.Tvdb.Should().Be(121361U);
            showIds.Imdb.Should().Be("tt0944947");
            showIds.Tmdb.Should().Be(1399U);
            showIds.TvRage.Should().Be(24493U);
            showIds.HasAnyId.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";
    }
}
