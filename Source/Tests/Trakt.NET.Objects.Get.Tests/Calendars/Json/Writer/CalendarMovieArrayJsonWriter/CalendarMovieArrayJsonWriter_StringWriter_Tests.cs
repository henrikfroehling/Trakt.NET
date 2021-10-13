namespace TraktNet.Objects.Get.Tests.Calendars.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonWriter")]
    public partial class CalendarMovieArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CalendarMovieArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarMovie>();
            IEnumerable<ITraktCalendarMovie> traktCalendarMovie = new List<TraktCalendarMovie>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCalendarMovie);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktCalendarMovie> traktCalendarMovie = new List<TraktCalendarMovie>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarMovie>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCalendarMovie);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktCalendarMovie> traktCalendarMovie = new List<ITraktCalendarMovie>
            {
                new TraktCalendarMovie
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarMovie>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCalendarMovie);
                json.Should().Be($"[{{\"released\":\"{TODAY.ToTraktDateString()}\"," +
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
                                 @"""certification"":""PG-13"",""country"":""us"",""comment_count"":153}}]");
            }
        }

        [Fact]
        public async Task Test_CalendarMovieArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktCalendarMovie> traktCalendarMovie = new List<ITraktCalendarMovie>
            {
                new TraktCalendarMovie
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
                },
                new TraktCalendarMovie
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarMovie>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCalendarMovie);
                json.Should().Be($"[{{\"released\":\"{TODAY.ToTraktDateString()}\"," +
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
                                 @"""certification"":""PG-13"",""country"":""us"",""comment_count"":153}}," +
                                 $"{{\"released\":\"{TODAY.ToTraktDateString()}\"," +
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
                                 @"""certification"":""PG-13"",""country"":""us"",""comment_count"":153}}]");
            }
        }
    }
}
