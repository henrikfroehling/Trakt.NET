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
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendationMovieArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_RecommendationMovieArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<TraktRecommendationMovie>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktRecommendationMovies);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<TraktRecommendationMovie>();

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationMovies);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<ITraktRecommendationMovie>
            {
                new TraktRecommendationMovie
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

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationMovies);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}]");
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<ITraktRecommendationMovie>
            {
                new TraktRecommendationMovie
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
                new TraktRecommendationMovie
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

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRecommendationMovies);
            json.Should().Be(@"[{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}," +
                             @"{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}]");
        }
    }
}
