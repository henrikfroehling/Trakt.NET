namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
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
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class RecommendationArrayJsonWriter_Tests
    {
        private readonly DateTime LISTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<TraktRecommendation>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktRecommendations);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktRecommendation> traktRecommendations = new List<TraktRecommendation>();

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendations);
            stringWriter.ToString().Should().Be("[]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_JsonWriter_SingleObject_Movie()
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

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendations);
            stringWriter.ToString().Should().Be(@"[{""rank"":1," +
                                                $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                                                @"""type"":""movie""," +
                                                @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                                                @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                                                @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                                                @"""imdb"":""tt1104001"",""tmdb"":20526}}}]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_JsonWriter_SingleObject_Show()
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

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendations);
            stringWriter.ToString().Should().Be(@"[{""rank"":1," +
                                                $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                                                @"""type"":""show""," +
                                                @"""notes"":""Atmospheric for days.""," +
                                                @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                                                @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                                                @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}]");
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            
            var traktJsonWriter = new ArrayJsonWriter<ITraktRecommendation>();
            await traktJsonWriter.WriteArrayAsync(jsonWriter, traktRecommendations);
            stringWriter.ToString().Should().Be(@"[{""rank"":1," +
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
