namespace TraktApiSharp.Tests.Objects.Get.People.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.Implementations;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Implementations")]
    public class TraktPersonIds_Tests
    {
        [Fact]
        public void Test_TraktPersonIds_Implements_ITraktPersonIds_Interface()
        {
            typeof(TraktPersonIds).GetInterfaces().Should().Contain(typeof(ITraktPersonIds));
        }

        [Fact]
        public void Test_TraktPersonIds_Default_Constructor()
        {
            var personIds = new TraktPersonIds();

            personIds.Trakt.Should().Be(0);
            personIds.Slug.Should().BeNullOrEmpty();
            personIds.Imdb.Should().BeNullOrEmpty();
            personIds.Tmdb.Should().BeNull();
            personIds.TvRage.Should().BeNull();
            personIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPersonIds_HasAnyId()
        {
            var personIds = new TraktPersonIds { Trakt = 1 };
            personIds.HasAnyId.Should().BeTrue();

            personIds = new TraktPersonIds { Slug = "slug" };
            personIds.HasAnyId.Should().BeTrue();

            personIds = new TraktPersonIds { Imdb = "imdb" };
            personIds.HasAnyId.Should().BeTrue();

            personIds = new TraktPersonIds { Tmdb = 1 };
            personIds.HasAnyId.Should().BeTrue();

            personIds = new TraktPersonIds { TvRage = 1 };
            personIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonIds_GetBestId()
        {
            var personIds = new TraktPersonIds();

            var bestId = personIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            personIds = new TraktPersonIds { Trakt = 1 };

            bestId = personIds.GetBestId();
            bestId.Should().Be("1");

            personIds = new TraktPersonIds { Slug = "slug" };

            bestId = personIds.GetBestId();
            bestId.Should().Be("slug");

            personIds = new TraktPersonIds { Imdb = "imdb" };

            bestId = personIds.GetBestId();
            bestId.Should().Be("imdb");

            personIds = new TraktPersonIds { Tmdb = 1 };

            bestId = personIds.GetBestId();
            bestId.Should().Be("1");

            personIds = new TraktPersonIds { TvRage = 1 };

            bestId = personIds.GetBestId();
            bestId.Should().Be("1");

            personIds = new TraktPersonIds
            {
                Trakt = 1,
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = personIds.GetBestId();
            bestId.Should().Be("1");

            personIds = new TraktPersonIds
            {
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = personIds.GetBestId();
            bestId.Should().Be("slug");

            personIds = new TraktPersonIds
            {
                Imdb = "imdb",
                Tmdb = 1,
                TvRage = 1
            };

            bestId = personIds.GetBestId();
            bestId.Should().Be("imdb");

            personIds = new TraktPersonIds
            {
                Tmdb = 1,
                TvRage = 1
            };

            bestId = personIds.GetBestId();
            bestId.Should().Be("1");
        }

        [Fact]
        public void Test_TraktPersonIds_From_Json()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();
            var personIds = jsonReader.ReadObject(JSON);

            personIds.Should().NotBeNull();
            personIds.Trakt.Should().Be(297737);
            personIds.Slug.Should().Be("bryan-cranston");
            personIds.Imdb.Should().Be("nm0186505");
            personIds.Tmdb.Should().Be(17419U);
            personIds.TvRage.Should().Be(1797U);
            personIds.HasAnyId.Should().BeTrue();
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
