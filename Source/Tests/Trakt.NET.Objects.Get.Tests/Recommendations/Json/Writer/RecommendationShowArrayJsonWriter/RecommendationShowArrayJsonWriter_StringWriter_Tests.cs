namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendationShowArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_RecommendationShowArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationShow>();
            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = new List<TraktRecommendationShow>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktRecommendationShows);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = new List<TraktRecommendationShow>();

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationShow>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationShows);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = new List<ITraktRecommendationShow>
            {
                new TraktRecommendationShow
                {
                    Rank = 1,
                    ListedAt = LISTED_AT,
                    Type = TraktRecommendationObjectType.Show,
                    Notes = "Atmospheric for days.",
                    Show = new TraktShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2U,
                            Slug = "the-walking-dead",
                            Tvdb = 153021U,
                            Imdb = "tt1520211",
                            Tmdb = 1402U
                        }
                    }
                }
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationShow>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationShows);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}]");
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = new List<ITraktRecommendationShow>
            {
                new TraktRecommendationShow
                {
                    Rank = 1,
                    ListedAt = LISTED_AT,
                    Type = TraktRecommendationObjectType.Show,
                    Notes = "Atmospheric for days.",
                    Show = new TraktShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2U,
                            Slug = "the-walking-dead",
                            Tvdb = 153021U,
                            Imdb = "tt1520211",
                            Tmdb = 1402U
                        }
                    }
                },
                new TraktRecommendationShow
                {
                    Rank = 1,
                    ListedAt = LISTED_AT,
                    Type = TraktRecommendationObjectType.Show,
                    Notes = "Atmospheric for days.",
                    Show = new TraktShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2U,
                            Slug = "the-walking-dead",
                            Tvdb = 153021U,
                            Imdb = "tt1520211",
                            Tmdb = 1402U
                        }
                    }
                }
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationShow>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationShows);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}," +
                             @"{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}]");
        }
    }
}
