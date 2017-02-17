namespace TraktApiSharp.Tests.Objects.Get.People
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using Xunit;

    [Category("Objects.Get.People")]
    public class TraktPersonIds_Tests
    {
        [Fact]
        public void Test_TraktPersonIds_Default_Constructor()
        {
            var showIds = new TraktPersonIds();

            showIds.Trakt.Should().Be(0);
            showIds.Slug.Should().BeNullOrEmpty();
            showIds.Imdb.Should().BeNullOrEmpty();
            showIds.Tmdb.Should().BeNull();
            showIds.TvRage.Should().BeNull();
            showIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPersonIds_HasAnyId()
        {
            var showIds = new TraktPersonIds { Trakt = 1 };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktPersonIds { Slug = "slug" };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktPersonIds { Imdb = "imdb" };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktPersonIds { Tmdb = 1 };
            showIds.HasAnyId.Should().BeTrue();

            showIds = new TraktPersonIds { TvRage = 1 };
            showIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonIds_GetBestId()
        {
            var showIds = new TraktPersonIds();

            var bestId = showIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            showIds = new TraktPersonIds { Trakt = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktPersonIds { Slug = "slug" };

            bestId = showIds.GetBestId();
            bestId.Should().Be("slug");

            showIds = new TraktPersonIds { Imdb = "imdb" };

            bestId = showIds.GetBestId();
            bestId.Should().Be("imdb");

            showIds = new TraktPersonIds { Tmdb = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktPersonIds { TvRage = 1 };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktPersonIds
            {
                Trakt = 1,
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");

            showIds = new TraktPersonIds
            {
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("slug");

            showIds = new TraktPersonIds
            {
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("imdb");

            showIds = new TraktPersonIds
            {
                Tmdb = 1,
                TvRage = 1
            };

            bestId = showIds.GetBestId();
            bestId.Should().Be("1");
        }

        [Fact]
        public void Test_TraktPersonIds_From_Json()
        {
            var showIds = JsonConvert.DeserializeObject<TraktPersonIds>(JSON);

            showIds.Should().NotBeNull();
            showIds.Trakt.Should().Be(297737);
            showIds.Slug.Should().Be("bryan-cranston");
            showIds.Imdb.Should().Be("nm0186505");
            showIds.Tmdb.Should().Be(17419U);
            showIds.TvRage.Should().Be(1797U);
            showIds.HasAnyId.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";
    }
}
