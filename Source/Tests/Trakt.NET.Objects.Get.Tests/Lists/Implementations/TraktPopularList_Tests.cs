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
    public class TraktPopularList_Tests
    {
        [Fact]
        public void Test_TraktPopularList_Default_Constructor()
        {
            var popularList = new TraktPopularList();

            popularList.LikeCount.Should().BeNull();
            popularList.CommentCount.Should().BeNull();
            popularList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPopularList_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new PopularListObjectJsonReader();
            var popularList = await jsonReader.ReadObjectAsync(JSON) as TraktPopularList;

            popularList.Should().NotBeNull();

            popularList.LikeCount.Should().Be(5);
            popularList.CommentCount.Should().Be(5);

            popularList.List.Should().NotBeNull();
            popularList.List.Name.Should().Be("Incredible Thoughts");
            popularList.List.Description.Should().Be("How could my brain conceive them?");
            popularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            popularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            popularList.List.Type.Should().Be(TraktListType.Personal);
            popularList.List.DisplayNumbers.Should().BeTrue();
            popularList.List.AllowComments.Should().BeTrue();
            popularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            popularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            popularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            popularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            popularList.List.ItemCount.Should().Be(50);
            popularList.List.CommentCount.Should().Be(10);
            popularList.List.Likes.Should().Be(99);

            popularList.List.Ids.Should().NotBeNull();
            popularList.List.Ids.Trakt.Should().Be(1337);
            popularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            popularList.List.User.Should().NotBeNull();
            popularList.List.User.Username.Should().Be("justin");
            popularList.List.User.IsPrivate.Should().BeFalse();
            popularList.List.User.Name.Should().Be("Justin Nemeth");
            popularList.List.User.IsVIP.Should().BeTrue();
            popularList.List.User.IsVIP_EP.Should().BeFalse();
            popularList.List.User.Ids.Should().NotBeNull();
            popularList.List.User.Ids.Slug.Should().Be("justin");
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
