namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonWriter")]
    public partial class RecommendationArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_RecommendationArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<TraktRecommendation>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRecommendations);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_Array_SingleObject_Movie()
        {
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<ITraktRecommendation>
            {
                new TraktRecommendation
                {
                    Rank = 1,
                    ListedAt = LISTED_AT,
                    Type = TraktRecommendationObjectType.Movie,
                    Notes = "Daft Punk really knocks it out of the park on the soundtrack.",
                    Movie = new TraktMovie
                    {
                        Title = "TRON: Legacy",
                        Year = 2010,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1U,
                            Slug = "tron-legacy-2010",
                            Imdb = "tt1104001",
                            Tmdb = 20526U
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRecommendations);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_Array_SingleObject_Show()
        {
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<ITraktRecommendation>
            {
                new TraktRecommendation
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRecommendations);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<ITraktRecommendation>
            {
                new TraktRecommendation
                {
                    Rank = 1,
                    ListedAt = LISTED_AT,
                    Type = TraktRecommendationObjectType.Movie,
                    Notes = "Daft Punk really knocks it out of the park on the soundtrack.",
                    Movie = new TraktMovie
                    {
                        Title = "TRON: Legacy",
                        Year = 2010,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1U,
                            Slug = "tron-legacy-2010",
                            Imdb = "tt1104001",
                            Tmdb = 20526U
                        }
                    }
                },
                new TraktRecommendation
                {
                    Rank = 2,
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRecommendations);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}," +
                             @"{""rank"":2," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}]");
        }
    }
}
