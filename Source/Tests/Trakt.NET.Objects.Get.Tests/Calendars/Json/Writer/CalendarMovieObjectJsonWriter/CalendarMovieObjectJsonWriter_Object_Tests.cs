namespace TraktNet.Objects.Get.Tests.Calendars.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Get.Calendars.Json.Writer;
    using TraktNet.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonWriter")]
    public partial class CalendarMovieObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CalendarMovieObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie();
            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCalendarMovie);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_Object_Only_CalendarRelease_Property()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie
            {
                CalendarRelease = TODAY
            };

            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCalendarMovie);
            json.Should().Be($"{{\"released\":\"{TODAY.ToTraktDateString()}\"}}");
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_Object_Only_Movie_Property()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie
            {
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
                    },
                    Tagline = "Every generation has a story.",
                    Overview = "Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.",
                    Released = RELEASED,
                    Runtime = 136,
                    UpdatedAt = UPDATED_AT,
                    Trailer = "http://youtube.com/watch?v=uwa7N0ShN2U",
                    Homepage = "http://www.starwars.com/films/star-wars-episode-vii",
                    Rating = 8.31988f,
                    Votes = 9338,
                    LanguageCode = "en",
                    AvailableTranslationLanguageCodes = new List<string>
                    {
                        "en",
                        "de",
                        "it"
                    },
                    Genres = new List<string>
                    {
                        "action",
                        "adventure",
                        "fantasy",
                        "science-fiction"
                    },
                    Certification = "PG-13",
                    CountryCode = "us",
                    CommentCount = 153
                }
            };

            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCalendarMovie);
            json.Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}," +
                             @"""tagline"":""Every generation has a story.""," +
                             @"""overview"":""Thirty years after defeating the Galactic Empire, " +
                             @"Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.""," +
                             $"\"released\":\"{RELEASED.ToTraktDateString()}\"," +
                             @"""runtime"":136,""trailer"":""http://youtube.com/watch?v=uwa7N0ShN2U""," +
                             @"""homepage"":""http://www.starwars.com/films/star-wars-episode-vii""," +
                             @"""rating"":8.31988,""votes"":9338," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""language"":""en"",""available_translations"":[" +
                             @"""en"",""de"",""it""],""genres"":[""action"",""adventure""," +
                             @"""fantasy"",""science-fiction""]," +
                             @"""certification"":""PG-13"",""country"":""us"",""comment_count"":153}}");
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie
            {
                CalendarRelease = TODAY,
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
                    },
                    Tagline = "Every generation has a story.",
                    Overview = "Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.",
                    Released = RELEASED,
                    Runtime = 136,
                    UpdatedAt = UPDATED_AT,
                    Trailer = "http://youtube.com/watch?v=uwa7N0ShN2U",
                    Homepage = "http://www.starwars.com/films/star-wars-episode-vii",
                    Rating = 8.31988f,
                    Votes = 9338,
                    LanguageCode = "en",
                    AvailableTranslationLanguageCodes = new List<string>
                    {
                        "en",
                        "de",
                        "it"
                    },
                    Genres = new List<string>
                    {
                        "action",
                        "adventure",
                        "fantasy",
                        "science-fiction"
                    },
                    Certification = "PG-13",
                    CountryCode = "us",
                    CommentCount = 153
                }
            };

            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCalendarMovie);
            json.Should().Be($"{{\"released\":\"{TODAY.ToTraktDateString()}\"," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}," +
                             @"""tagline"":""Every generation has a story.""," +
                             @"""overview"":""Thirty years after defeating the Galactic Empire, " +
                             @"Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.""," +
                             $"\"released\":\"{RELEASED.ToTraktDateString()}\"," +
                             @"""runtime"":136,""trailer"":""http://youtube.com/watch?v=uwa7N0ShN2U""," +
                             @"""homepage"":""http://www.starwars.com/films/star-wars-episode-vii""," +
                             @"""rating"":8.31988,""votes"":9338," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""language"":""en"",""available_translations"":[" +
                             @"""en"",""de"",""it""],""genres"":[""action"",""adventure""," +
                             @"""fantasy"",""science-fiction""]," +
                             @"""certification"":""PG-13"",""country"":""us"",""comment_count"":153}}");
        }
    }
}
