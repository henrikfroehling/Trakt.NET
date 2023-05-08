namespace TraktNet.Objects.Get.Tests.Calendars.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);
                traktCalendarShows.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().BeNull();
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().BeNull();
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().BeNull();
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().BeNull();
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);

                traktCalendarShows.Should().NotBeNull();
                ITraktCalendarShow[] calendarShows = traktCalendarShows.ToArray();

                calendarShows[0].Should().NotBeNull();
                calendarShows[0].FirstAiredInCalendar.Should().BeNull();
                calendarShows[0].Show.Should().NotBeNull();
                calendarShows[0].Show.Title.Should().Be("Game of Thrones");
                calendarShows[0].Show.Year.Should().Be(2011);
                calendarShows[0].Show.Ids.Should().NotBeNull();
                calendarShows[0].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[0].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[0].Episode.Should().NotBeNull();
                calendarShows[0].Episode.SeasonNumber.Should().Be(1);
                calendarShows[0].Episode.Number.Should().Be(1);
                calendarShows[0].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[0].Episode.Ids.Should().NotBeNull();
                calendarShows[0].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[0].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                calendarShows[1].Should().NotBeNull();
                calendarShows[1].FirstAiredInCalendar.Should().BeNull();
                calendarShows[1].Show.Should().NotBeNull();
                calendarShows[1].Show.Title.Should().Be("Game of Thrones");
                calendarShows[1].Show.Year.Should().Be(2011);
                calendarShows[1].Show.Ids.Should().NotBeNull();
                calendarShows[1].Show.Ids.Trakt.Should().Be(1390U);
                calendarShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                calendarShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                calendarShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                calendarShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                calendarShows[1].Show.Ids.TvRage.Should().Be(24493U);
                calendarShows[1].Episode.Should().NotBeNull();
                calendarShows[1].Episode.SeasonNumber.Should().Be(1);
                calendarShows[1].Episode.Number.Should().Be(1);
                calendarShows[1].Episode.Title.Should().Be("Winter Is Coming");
                calendarShows[1].Episode.Ids.Should().NotBeNull();
                calendarShows[1].Episode.Ids.Trakt.Should().Be(73640U);
                calendarShows[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                calendarShows[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                calendarShows[1].Episode.Ids.Tmdb.Should().Be(63056U);
                calendarShows[1].Episode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();
            Func<Task<IList<ITraktCalendarShow>>> traktCalendarShows = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktCalendarShows.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCalendarShow>();

            using (var stream = string.Empty.ToStream())
            {
                IList<ITraktCalendarShow> traktCalendarShows = await jsonReader.ReadArrayAsync(stream);
                traktCalendarShows.Should().BeNull();
            }
        }
    }
}
