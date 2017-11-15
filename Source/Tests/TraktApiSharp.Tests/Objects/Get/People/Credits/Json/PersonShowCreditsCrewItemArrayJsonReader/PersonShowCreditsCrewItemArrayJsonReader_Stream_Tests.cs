namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);
                showCreditsCrewItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);

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
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(default(Stream));
            showCreditsCrewItems.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new PersonShowCreditsCrewItemArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var showCreditsCrewItems = await traktJsonReader.ReadArrayAsync(stream);
                showCreditsCrewItems.Should().BeNull();
            }
        }
    }
}
