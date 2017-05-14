namespace TraktApiSharp.Tests.Objects.Get.Calendars.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars.JsonReader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class TraktCalendarShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCalendarShow.Show.Should().BeNull();

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCalendarShow.Show.Should().BeNull();
                traktCalendarShow.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().BeNull();
                traktCalendarShow.Show.Should().BeNull();

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCalendarShow.Show.Should().BeNull();

                traktCalendarShow.Episode.Should().NotBeNull();
                traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
                traktCalendarShow.Episode.Number.Should().Be(1);
                traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
                traktCalendarShow.Episode.Ids.Should().NotBeNull();
                traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
                traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
                traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCalendarShow.Show.Should().NotBeNull();
                traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
                traktCalendarShow.Show.Year.Should().Be(2011);
                traktCalendarShow.Show.Ids.Should().NotBeNull();
                traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCalendarShow.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCalendarShow.Should().NotBeNull();
                traktCalendarShow.FirstAiredInCalendar.Should().BeNull();
                traktCalendarShow.Show.Should().BeNull();
                traktCalendarShow.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            var traktCalendarShow = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCalendarShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCalendarShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktCalendarShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCalendarShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCalendarShow.Should().BeNull();
            }
        }
    }
}
