namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
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
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeObjectJsonWriter_Tests
    {
        private static readonly DateTime FIRST_AIRED = DateTime.UtcNow.AddMonths(-1);
        private static readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeObjectJsonWriter();
            ITraktEpisode traktEpisode = new TraktEpisode();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktEpisode);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_SeasonNumber_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                SeasonNumber = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""season"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Number_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Title_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Title = "title"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""title"":""title""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Ids_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 123456,
                    Tvdb = 234567,
                    Imdb = "345678",
                    Tmdb = 456789,
                    TvRage = 567890
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_NumberAbsolute_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                NumberAbsolute = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""number_abs"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Overview_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Overview = "overview"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""overview"":""overview""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Runtime_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Runtime = 60
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""runtime"":60}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Rating_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Rating = 8.45672f
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""rating"":8.45672}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Votes_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Votes = 8925
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""votes"":8925}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_FirstAired_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                FirstAired = FIRST_AIRED
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be($"{{\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_UpdatedAt_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                UpdatedAt = UPDATED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_AvailableTranslationLanguageCodes_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                AvailableTranslationLanguageCodes = new List<string>
                {
                    "en",
                    "de"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""available_translations"":[""en"",""de""]}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Only_Translations_Property()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                Translations = new List<ITraktEpisodeTranslation>
                {
                    new TraktEpisodeTranslation
                    {
                        Title = "german title",
                        Overview = "german overview",
                        LanguageCode = "de"
                    },
                    new TraktEpisodeTranslation
                    {
                        Title = "english title",
                        Overview = "english overview",
                        LanguageCode = "en"
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""translations"":[{""title"":""german title"",""overview"":""german overview"",""language"":""de""}," +
                                                    @"{""title"":""english title"",""overview"":""english overview"",""language"":""en""}]}");
            }
        }

        [Fact]
        public async Task Test_EpisodeObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktEpisode traktEpisode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Title = "title",
                Ids = new TraktEpisodeIds
                {
                    Trakt = 123456,
                    Tvdb = 234567,
                    Imdb = "345678",
                    Tmdb = 456789,
                    TvRage = 567890
                },
                NumberAbsolute = 1,
                Overview = "overview",
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
                Translations = new List<ITraktEpisodeTranslation>
                {
                    new TraktEpisodeTranslation
                    {
                        Title = "german title",
                        Overview = "german overview",
                        LanguageCode = "de"
                    },
                    new TraktEpisodeTranslation
                    {
                        Title = "english title",
                        Overview = "english overview",
                        LanguageCode = "en"
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisode);
                stringWriter.ToString().Should().Be(@"{""season"":1,""number"":1,""title"":""title""," +
                                                    @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                                                    @"""number_abs"":1,""overview"":""overview""," +
                                                    @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""de""]," +
                                                    @"""translations"":[{""title"":""german title"",""overview"":""german overview"",""language"":""de""}," +
                                                    @"{""title"":""english title"",""overview"":""english overview"",""language"":""en""}]}");
            }
        }
    }
}
