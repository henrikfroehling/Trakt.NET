namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                showCreditsCrewItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().NotBeNull();
                items[1].Show.Title.Should().Be("The Flash");
                items[1].Show.Year.Should().Be(2014);
                items[1].Show.Ids.Should().NotBeNull();
                items[1].Show.Ids.Trakt.Should().Be(60300U);
                items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                items[1].Show.Ids.Tvdb.Should().Be(279121U);
                items[1].Show.Ids.Imdb.Should().Be("tt3107288");
                items[1].Show.Ids.Tmdb.Should().Be(60735U);
                items[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().NotBeNull();
                items[1].Show.Title.Should().Be("The Flash");
                items[1].Show.Year.Should().Be(2014);
                items[1].Show.Ids.Should().NotBeNull();
                items[1].Show.Ids.Trakt.Should().Be(60300U);
                items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                items[1].Show.Ids.Tvdb.Should().Be(279121U);
                items[1].Show.Ids.Imdb.Should().Be("tt3107288");
                items[1].Show.Ids.Tmdb.Should().Be(60735U);
                items[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().NotBeNull();
                items[1].Show.Title.Should().Be("The Flash");
                items[1].Show.Year.Should().Be(2014);
                items[1].Show.Ids.Should().NotBeNull();
                items[1].Show.Ids.Trakt.Should().Be(60300U);
                items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
                items[1].Show.Ids.Tvdb.Should().Be(279121U);
                items[1].Show.Ids.Imdb.Should().Be("tt3107288");
                items[1].Show.Ids.Tmdb.Should().Be(60735U);
                items[1].Show.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                showCreditsCrewItems.Should().NotBeNull();
                var items = showCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Show.Should().NotBeNull();
                items[0].Show.Title.Should().Be("Game of Thrones");
                items[0].Show.Year.Should().Be(2011);
                items[0].Show.Ids.Should().NotBeNull();
                items[0].Show.Ids.Trakt.Should().Be(1390U);
                items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                items[0].Show.Ids.Tvdb.Should().Be(121361U);
                items[0].Show.Ids.Imdb.Should().Be("tt0944947");
                items[0].Show.Ids.Tmdb.Should().Be(1399U);
                items[0].Show.Ids.TvRage.Should().Be(24493U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            showCreditsCrewItems.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCrewItem>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                showCreditsCrewItems.Should().BeNull();
            }
        }
    }
}
