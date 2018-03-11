namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisode>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktEpisode>));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktEpisode> traktEpisodes = new List<TraktEpisode>();

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisode>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodes);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktEpisode> traktEpisodes = new List<ITraktEpisode>
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisode>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodes);
            json.Should().Be(@"[{""season"":1,""number"":1,""title"":""title 1""," +
                             @"""ids"":{""trakt"":123456,""tvdb"":234567,""imdb"":""345678"",""tmdb"":456789,""tvrage"":567890}," +
                             @"""number_abs"":1,""overview"":""overview 1""," +
                             @"""runtime"":60,""rating"":8.45672,""votes"":8925," +
                             $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""available_translations"":[""en"",""de""]," +
                             @"""translations"":[{""title"":""german title 1"",""overview"":""german overview 1"",""language"":""de""}," +
                             @"{""title"":""english title 1"",""overview"":""english overview 1"",""language"":""en""}]}]");
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktEpisode> traktEpisodes = new List<ITraktEpisode>
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
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisode>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodes);
            json.Should().Be(@"[{""season"":1,""number"":1,""title"":""title 1""," +
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
                             @"{""title"":""english title 2"",""overview"":""english overview 2"",""language"":""en""}]}]");
        }
    }
}
