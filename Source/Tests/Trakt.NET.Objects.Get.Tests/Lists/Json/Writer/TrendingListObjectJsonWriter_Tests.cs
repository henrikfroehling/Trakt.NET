namespace TraktNet.Objects.Get.Tests.Lists.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonWriter")]
    public class TrendingTrendingListObjectJsonWriter_Tests
    {
        private readonly DateTime CREATED_AT = DateTime.UtcNow;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new TrendingListObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Empty()
        {
            var traktJsonWriter = new TrendingListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktTrendingList());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Only_LikeCount_Property()
        {
            ITraktTrendingList trendingList = new TraktTrendingList
            {
                LikeCount = 5
            };

            var traktJsonWriter = new TrendingListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(trendingList);
            json.Should().Be(@"{""like_count"":5}");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Only_CommentCount_Property()
        {
            ITraktTrendingList trendingList = new TraktTrendingList
            {
                CommentCount = 5
            };

            var traktJsonWriter = new TrendingListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(trendingList);
            json.Should().Be(@"{""comment_count"":5}");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Only_List_Property()
        {
            ITraktTrendingList trendingList = new TraktTrendingList
            {
                List = new TraktList
                {
                    Name = "Incredible Thoughts",
                    Description = "How could my brain conceive them?",
                    Privacy = TraktListPrivacy.Public,
                    ShareLink = "https://trakt.tv/lists/1337",
                    Type = TraktListType.Personal,
                    DisplayNumbers = true,
                    AllowComments = true,
                    SortBy = TraktSortBy.Rank,
                    SortHow = TraktSortHow.Ascending,
                    CreatedAt = CREATED_AT,
                    UpdatedAt = UPDATED_AT,
                    ItemCount = 50,
                    CommentCount = 10,
                    Likes = 99,
                    Ids = new TraktListIds
                    {
                        Trakt = 1337,
                        Slug = "incredible-thoughts"
                    },
                    User = new TraktUser
                    {
                        Username = "justin",
                        IsPrivate = false,
                        Name = "Justin Nemeth",
                        IsVIP = true,
                        IsVIP_EP = false,
                        Ids = new TraktUserIds
                        {
                            Slug = "justin"
                        }
                    }
                }
            };

            var traktJsonWriter = new TrendingListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(trendingList);
            json.Should().Be(@"{""list"":{""name"":""Incredible Thoughts""," +
                             @"""description"":""How could my brain conceive them?""," +
                             @"""privacy"":""public"",""share_link"":""https://trakt.tv/lists/1337""," +
                             @"""type"":""personal"",""display_numbers"":true," +
                             @"""allow_comments"":true,""sort_by"":""rank"",""sort_how"":""asc""," +
                             $"\"created_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""item_count"":50,""comment_count"":10,""likes"":99," +
                             @"""ids"":{""trakt"":1337,""slug"":""incredible-thoughts""}," +
                             @"""user"":{""username"":""justin"",""private"":false," +
                             @"""ids"":{""slug"":""justin""},""name"":""Justin Nemeth""," +
                             @"""vip"":true,""vip_ep"":false}}}");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonWriter_WriteObject_Complete()
        {
            ITraktTrendingList trendingList = new TraktTrendingList
            {
                LikeCount = 5,
                CommentCount = 5,
                List = new TraktList
                {
                    Name = "Incredible Thoughts",
                    Description = "How could my brain conceive them?",
                    Privacy = TraktListPrivacy.Public,
                    ShareLink = "https://trakt.tv/lists/1337",
                    Type = TraktListType.Personal,
                    DisplayNumbers = true,
                    AllowComments = true,
                    SortBy = TraktSortBy.Rank,
                    SortHow = TraktSortHow.Ascending,
                    CreatedAt = CREATED_AT,
                    UpdatedAt = UPDATED_AT,
                    ItemCount = 50,
                    CommentCount = 10,
                    Likes = 99,
                    Ids = new TraktListIds
                    {
                        Trakt = 1337,
                        Slug = "incredible-thoughts"
                    },
                    User = new TraktUser
                    {
                        Username = "justin",
                        IsPrivate = false,
                        Name = "Justin Nemeth",
                        IsVIP = true,
                        IsVIP_EP = false,
                        Ids = new TraktUserIds
                        {
                            Slug = "justin"
                        }
                    }
                }
            };

            var traktJsonWriter = new TrendingListObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(trendingList);
            json.Should().Be(@"{""like_count"":5,""comment_count"":5," +
                             @"""list"":{""name"":""Incredible Thoughts""," +
                             @"""description"":""How could my brain conceive them?""," +
                             @"""privacy"":""public"",""share_link"":""https://trakt.tv/lists/1337""," +
                             @"""type"":""personal"",""display_numbers"":true," +
                             @"""allow_comments"":true,""sort_by"":""rank"",""sort_how"":""asc""," +
                             $"\"created_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""item_count"":50,""comment_count"":10,""likes"":99," +
                             @"""ids"":{""trakt"":1337,""slug"":""incredible-thoughts""}," +
                             @"""user"":{""username"":""justin"",""private"":false," +
                             @"""ids"":{""slug"":""justin""},""name"":""Justin Nemeth""," +
                             @"""vip"":true,""vip_ep"":false}}}");
        }
    }
}
