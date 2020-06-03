namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonArrayJsonWriter_Tests
    {
        private static readonly DateTime FIRST_AIRED = DateTime.UtcNow.AddMonths(-1);
        private static readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_SeasonArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSeason>();
            IEnumerable<ITraktSeason> traktSeasons = new List<TraktSeason>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktSeasons);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktSeason> traktSeasons = new List<TraktSeason>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasons);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SeasonArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktSeason> traktSeasons = new List<ITraktSeason>
            {
                new TraktSeason
                {
                    Number = 1,
                    Title = "Season 1",
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 123,
                        Tvdb = 456,
                        Tmdb = 789,
                        TvRage = 101
                    },
                    Rating = 8.7654f,
                    Votes = 9765,
                    TotalEpisodesCount = 24,
                    AiredEpisodesCount = 12,
                    Overview = "Season 1 Overview",
                    FirstAired = FIRST_AIRED,
                    Network = "Season 1 Network",
                    Episodes = new List<ITraktEpisode>
                    {
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 1,
                            Title = "title 1",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 1,
                            Overview = "overview 1",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 1",
                                    Overview = "german overview 1",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 1",
                                    Overview = "english overview 1",
                                    LanguageCode = "en"
                                }
                            }
                        },
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 2,
                            Title = "title 2",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 2,
                            Overview = "overview 2",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 2",
                                    Overview = "german overview 2",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 2",
                                    Overview = "english overview 2",
                                    LanguageCode = "en"
                                }
                            }
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasons);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""title"":""Season 1""," +
                                                    @"""ids"":{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}," +
                                                    @"""rating"":8.7654,""votes"":9765,""episode_count"":24,""aired_episodes"":12," +
                                                    @"""overview"":""Season 1 Overview""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""network"":""Season 1 Network""," +
                                                    @"""episodes"":[" +
                                                    @"{""season"":1,""number"":1,""title"":""title 1""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":1,""overview"":""overview 1""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 1"",""overview"":""german overview 1"",""language"":""de""}," +
                                                    @"{""title"":""english title 1"",""overview"":""english overview 1"",""language"":""en""}]}," +
                                                    @"{""season"":1,""number"":2,""title"":""title 2""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":2,""overview"":""overview 2""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 2"",""overview"":""german overview 2"",""language"":""de""}," +
                                                    @"{""title"":""english title 2"",""overview"":""english overview 2"",""language"":""en""}]}" +
                                                    "]}]");
            }
        }

        [Fact]
        public async Task Test_SeasonArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktSeason> traktSeasons = new List<ITraktSeason>
            {
                new TraktSeason
                {
                    Number = 1,
                    Title = "Season 1",
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 123,
                        Tvdb = 456,
                        Tmdb = 789,
                        TvRage = 101
                    },
                    Rating = 8.7654f,
                    Votes = 9765,
                    TotalEpisodesCount = 24,
                    AiredEpisodesCount = 12,
                    Overview = "Season 1 Overview",
                    FirstAired = FIRST_AIRED,
                    Network = "Season 1 Network",
                    Episodes = new List<ITraktEpisode>
                    {
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 1,
                            Title = "title 1",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 1,
                            Overview = "overview 1",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 1",
                                    Overview = "german overview 1",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 1",
                                    Overview = "english overview 1",
                                    LanguageCode = "en"
                                }
                            }
                        },
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 2,
                            Title = "title 2",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 2,
                            Overview = "overview 2",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 2",
                                    Overview = "german overview 2",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 2",
                                    Overview = "english overview 2",
                                    LanguageCode = "en"
                                }
                            }
                        }
                    }
                },
                new TraktSeason
                {
                    Number = 2,
                    Title = "Season 2",
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 123,
                        Tvdb = 456,
                        Tmdb = 789,
                        TvRage = 101
                    },
                    Rating = 8.7654f,
                    Votes = 9765,
                    TotalEpisodesCount = 24,
                    AiredEpisodesCount = 12,
                    Overview = "Season 2 Overview",
                    FirstAired = FIRST_AIRED,
                    Network = "Season 2 Network",
                    Episodes = new List<ITraktEpisode>
                    {
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 1,
                            Title = "title 1",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 1,
                            Overview = "overview 1",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 1",
                                    Overview = "german overview 1",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 1",
                                    Overview = "english overview 1",
                                    LanguageCode = "en"
                                }
                            }
                        },
                        new TraktEpisode
                        {
                            SeasonNumber = 1,
                            Number = 2,
                            Title = "title 2",
                            Ids = new TraktEpisodeIds
                            {
                                Trakt = 123456,
                                Tvdb = 234567,
                                Imdb = "345678",
                                Tmdb = 456789,
                                TvRage = 567890
                            },
                            NumberAbsolute = 2,
                            Overview = "overview 2",
                            Runtime = 60,
                            Rating = 8.45672f,
                            Votes = 8925,
                            FirstAired = FIRST_AIRED,
                            UpdatedAt = UPDATED_AT,
                            AvailableTranslationLanguageCodes = new List<string>
                            {
                                "en",
                                "de"
                            },
                            Translations = new List<TraktEpisodeTranslation>
                            {
                                new TraktEpisodeTranslation
                                {
                                    Title = "german title 2",
                                    Overview = "german overview 2",
                                    LanguageCode = "de"
                                },
                                new TraktEpisodeTranslation
                                {
                                    Title = "english title 2",
                                    Overview = "english overview 2",
                                    LanguageCode = "en"
                                }
                            }
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasons);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""title"":""Season 1""," +
                                                    @"""ids"":{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}," +
                                                    @"""rating"":8.7654,""votes"":9765,""episode_count"":24,""aired_episodes"":12," +
                                                    @"""overview"":""Season 1 Overview""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""network"":""Season 1 Network""," +
                                                    @"""episodes"":[" +
                                                    @"{""season"":1,""number"":1,""title"":""title 1""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":1,""overview"":""overview 1""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 1"",""overview"":""german overview 1"",""language"":""de""}," +
                                                    @"{""title"":""english title 1"",""overview"":""english overview 1"",""language"":""en""}]}," +
                                                    @"{""season"":1,""number"":2,""title"":""title 2""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":2,""overview"":""overview 2""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 2"",""overview"":""german overview 2"",""language"":""de""}," +
                                                    @"{""title"":""english title 2"",""overview"":""english overview 2"",""language"":""en""}]}" +
                                                    "]}," +
                                                    @"{""number"":2,""title"":""Season 2""," +
                                                    @"""ids"":{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}," +
                                                    @"""rating"":8.7654,""votes"":9765,""episode_count"":24,""aired_episodes"":12," +
                                                    @"""overview"":""Season 2 Overview""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""network"":""Season 2 Network""," +
                                                    @"""episodes"":[" +
                                                    @"{""season"":1,""number"":1,""title"":""title 1""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":1,""overview"":""overview 1""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 1"",""overview"":""german overview 1"",""language"":""de""}," +
                                                    @"{""title"":""english title 1"",""overview"":""english overview 1"",""language"":""en""}]}," +
                                                    @"{""season"":1,""number"":2,""title"":""title 2""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":2,""overview"":""overview 2""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title 2"",""overview"":""german overview 2"",""language"":""de""}," +
                                                    @"{""title"":""english title 2"",""overview"":""english overview 2"",""language"":""en""}]}" +
                                                    "]}]");
            }
        }
    }
}
