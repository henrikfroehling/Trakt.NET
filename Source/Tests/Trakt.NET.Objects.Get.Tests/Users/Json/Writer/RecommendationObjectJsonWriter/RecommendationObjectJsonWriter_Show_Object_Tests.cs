namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using TraktNet.Objects.Get.Shows;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class RecommendationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new RecommendationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Only_Rank_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Rank = 1
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be(@"{""rank"":1}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Only_ListedAt_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                ListedAt = LISTED_AT
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be($"{{\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Only_Type_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Type = TraktRecommendationObjectType.Show
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be(@"{""type"":""show""}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Only_Notes_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
                Notes = "Atmospheric for days."
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be(@"{""notes"":""Atmospheric for days.""}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Only_Show_Property()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
            {
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
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be(@"{""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonWriter_Show_WriteObject_Object_Complete()
        {
            ITraktRecommendation traktRecommendation = new TraktRecommendation
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
            };

            var traktJsonWriter = new RecommendationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktRecommendation);
            json.Should().Be(@"{""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }
    }
}
