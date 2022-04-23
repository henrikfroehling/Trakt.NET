﻿namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Users.JsonWriter")]
    public partial class RecommendationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new RecommendationObjectJsonWriter();
            ITraktRecommendation traktRecommendation = new TraktRecommendation();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktRecommendation);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Only_Rank_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Rank = 1
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be(@"{""rank"":1}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Only_ListedAt_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                ListedAt = LISTED_AT
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be($"{{\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Only_Type_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Type = TraktRecommendationObjectType.Movie
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be(@"{""type"":""movie""}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Only_Notes_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Notes = "Daft Punk really knocks it out of the park on the soundtrack."
            };

            using var stringWriter = new StringWriter();

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be(@"{""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Only_Movie_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
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

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be(@"{""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Movie_WriteObject_StringWriter_Complete()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
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

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktRecommendation);
            json.Should().Be(@"{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }
    }
}
