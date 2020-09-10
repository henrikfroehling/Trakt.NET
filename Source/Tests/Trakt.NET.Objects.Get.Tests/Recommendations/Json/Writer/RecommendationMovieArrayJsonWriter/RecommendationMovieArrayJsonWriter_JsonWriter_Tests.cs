namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        private readonly DateTime LISTED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_RecommendationMovieArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<TraktRecommendationMovie>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktRecommendationMovies);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = new List<TraktRecommendationMovie>();

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendationMovies);
            stringWriter.ToString().Should().Be("[]");
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendationMovies);
            stringWriter.ToString().Should().Be(@"[{""rank"":1," +
                                                $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                                                @"""type"":""movie""," +
                                                @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                                                @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                                                @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                                                @"""imdb"":""tt1104001"",""tmdb"":20526}}}]");
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendationMovie>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendationMovies);
            stringWriter.ToString().Should().Be(@"[{""rank"":1," +
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
