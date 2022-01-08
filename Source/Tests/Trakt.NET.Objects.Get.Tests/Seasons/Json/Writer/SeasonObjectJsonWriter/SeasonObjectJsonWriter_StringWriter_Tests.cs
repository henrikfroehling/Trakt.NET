namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SeasonObjectJsonWriter();
            ITraktSeason traktSeason = new TraktSeason();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSeason);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Number_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Title_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Title = "Season 1"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""title"":""Season 1""}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Ids_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 123,
                    Tvdb = 456,
                    Tmdb = 789,
                    TvRage = 101
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""ids"":{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Rating_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Rating = 8.7654f
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""rating"":8.7654}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Votes_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Votes = 9765
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""votes"":9765}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_TotalEpisodesCount_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                TotalEpisodesCount = 24
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""episode_count"":24}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_AiredEpisodesCount_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                AiredEpisodesCount = 12
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""aired_episodes"":12}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Overview_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Overview = "Season 1 Overview"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""overview"":""Season 1 Overview""}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_FirstAired_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                FirstAired = FIRST_AIRED
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be($"{{\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_UpdatedAt_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                UpdatedAt = UPDATED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Network_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
                Network = "Season 1 Network"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""network"":""Season 1 Network""}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Only_Episodes_Property()
        {
            ITraktSeason traktSeason = new TraktSeason
            {
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""episodes"":[" +
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
                                 "]}");
            }
        }

        [Fact]
        public async Task Test_SeasonObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktSeason traktSeason = new TraktSeason
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
                UpdatedAt = UPDATED_AT,
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeason);
                json.Should().Be(@"{""number"":1,""title"":""Season 1""," +
                                 @"""ids"":{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}," +
                                 @"""rating"":8.7654,""votes"":9765,""episode_count"":24,""aired_episodes"":12," +
                                 @"""overview"":""Season 1 Overview""," +
                                 $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                 $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
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
                                 "]}");
            }
        }
    }
}
