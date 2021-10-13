namespace TraktNet.Objects.Get.Tests.Calendars.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;
        private readonly DateTime TODAY = DateTime.Today;
        private readonly DateTime RELEASED = new DateTime(2015, 12, 18);

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CalendarMovieObjectJsonWriter();
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCalendarMovie);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CalendarMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCalendarMovie);
                stringWriter.ToString().Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_JsonWriter_Only_CalendarRelease_Property()
        {
            ITraktCalendarMovie traktCalendarMovie = new TraktCalendarMovie
            {
                CalendarRelease = TODAY
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CalendarMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCalendarMovie);
                stringWriter.ToString().Should().Be($"{{\"released\":\"{TODAY.ToTraktDateString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Movie_Property()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CalendarMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCalendarMovie);
                stringWriter.ToString().Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
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

        [Fact]
        public async Task Test_CalendarMovieObjectJsonWriter_WriteObject_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CalendarMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCalendarMovie);
                stringWriter.ToString().Should().Be($"{{\"released\":\"{TODAY.ToTraktDateString()}\"," +
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
}
