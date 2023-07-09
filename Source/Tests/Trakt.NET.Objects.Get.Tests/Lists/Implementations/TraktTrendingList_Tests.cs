namespace TraktNet.Objects.Get.Tests.Lists.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.Implementations")]
    public class TraktTrendingList_Tests
    {
        [Fact]
        public void Test_TraktTrendingList_Default_Constructor()
        {
            var trendingList = new TraktTrendingList();

            trendingList.LikeCount.Should().BeNull();
            trendingList.CommentCount.Should().BeNull();
            trendingList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktTrendingList_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new TrendingListObjectJsonReader();
            var trendingList = await jsonReader.ReadObjectAsync(JSON) as TraktTrendingList;

            trendingList.Should().NotBeNull();

            trendingList.LikeCount.Should().Be(5);
            trendingList.CommentCount.Should().Be(5);
            
            trendingList.List.Should().NotBeNull();
            trendingList.List.Name.Should().Be("Incredible Thoughts");
            trendingList.List.Description.Should().Be("How could my brain conceive them?");
            trendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            trendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            trendingList.List.Type.Should().Be(TraktListType.Personal);
            trendingList.List.DisplayNumbers.Should().BeTrue();
            trendingList.List.AllowComments.Should().BeTrue();
            trendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            trendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            trendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            trendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            trendingList.List.ItemCount.Should().Be(50);
            trendingList.List.CommentCount.Should().Be(10);
            trendingList.List.Likes.Should().Be(99);

            trendingList.List.Ids.Should().NotBeNull();
            trendingList.List.Ids.Trakt.Should().Be(1337);
            trendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            trendingList.List.User.Should().NotBeNull();
            trendingList.List.User.Username.Should().Be("justin");
            trendingList.List.User.IsPrivate.Should().BeFalse();
            trendingList.List.User.Name.Should().Be("Justin Nemeth");
            trendingList.List.User.IsVIP.Should().BeTrue();
            trendingList.List.User.IsVIP_EP.Should().BeFalse();
            trendingList.List.User.Ids.Should().NotBeNull();
            trendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        private const string JSON =
            @"{
                ""like_count"": 5,
                ""comment_count"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";
    }
}
