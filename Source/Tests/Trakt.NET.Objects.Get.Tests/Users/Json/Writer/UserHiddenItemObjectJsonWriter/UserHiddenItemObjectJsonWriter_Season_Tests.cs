namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class UserHiddenItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Season_WriteObject_Object_Only_HiddenAt_Property()
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
        public async Task Test_UserHiddenItemObjectJsonWriter_Season_WriteObject_Object_Only_Type_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                Type = TraktHiddenItemType.Season
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""type"":""season""}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Season_WriteObject_Object_Only_Season_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                Season = new TraktSeason
                {
                    Number = 1,
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 61430U,
                        Tvdb = 279121U,
                        Tmdb = 60523U,
                        TvRage = 36939U
                    }
                }
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""season"":{""number"":1," +
                             @"""ids"":{""trakt"":61430,""tvdb"":279121," +
                             @"""tmdb"":60523,""tvrage"":36939}}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Season_WriteObject_Object_Complete()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT,
                Type = TraktHiddenItemType.Season,
                Season = new TraktSeason
                {
                    Number = 1,
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 61430U,
                        Tvdb = 279121U,
                        Tmdb = 60523U,
                        TvRage = 36939U
                    }
                }
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""season""," +
                             @"""season"":{""number"":1," +
                             @"""ids"":{""trakt"":61430,""tvdb"":279121," +
                             @"""tmdb"":60523,""tvrage"":36939}}}");
        }
    }
}
