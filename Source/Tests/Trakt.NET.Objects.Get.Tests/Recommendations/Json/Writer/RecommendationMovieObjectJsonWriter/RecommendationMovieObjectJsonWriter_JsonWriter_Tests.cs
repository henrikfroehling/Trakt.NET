namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonWriter")]
    public partial class RecommendationMovieObjectJsonWriter_Tests
    {
        private readonly DateTime LISTED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktRecommendationMovie);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Rank_Property()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
            {
                Rank = 1
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be(@"{""rank"":1}");
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Only_ListedAt_Property()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
            {
                ListedAt = LISTED_AT
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be($"{{\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Type_Property()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
            {
                Type = TraktRecommendationObjectType.Movie
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be(@"{""type"":""movie""}");
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Notes_Property()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
            {
                Notes = "Daft Punk really knocks it out of the park on the soundtrack."
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be(@"{""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""}");
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Movie_Property()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
            {
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
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be(@"{""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                                                @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                                                @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie
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
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new RecommendationMovieObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRecommendationMovie);
            stringWriter.ToString().Should().Be(@"{""rank"":1," +
                                                $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                                                @"""type"":""movie""," +
                                                @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                                                @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                                                @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                                                @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }
    }
}
