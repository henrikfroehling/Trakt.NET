namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class UserHiddenItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Show_WriteObject_Object_Only_HiddenAt_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Show_WriteObject_Object_Only_Type_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                Type = TraktHiddenItemType.Show
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""type"":""show""}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Show_WriteObject_Object_Only_Show_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
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

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Show_WriteObject_Object_Complete()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT,
                Type = TraktHiddenItemType.Show,
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

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }
    }
}
