namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktUserLikeItem_Tests
    {
        [Fact]
        public void Test_TraktUserLikeItem_Default_Constructor()
        {
            var likeItem = new TraktUserLikeItem();

            likeItem.LikedAt.Should().BeNull();
            likeItem.Type.Should().BeNull();
            likeItem.Comment.Should().BeNull();
            likeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItem_With_Type_Comment_From_Json()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();
            var likeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON) as TraktUserLikeItem;

            likeItem.Should().NotBeNull();
            likeItem.Should().NotBeNull();
            likeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            likeItem.Type.Should().Be(TraktUserLikeType.Comment);
            likeItem.Comment.Should().NotBeNull();
            likeItem.Comment.Id.Should().Be(76957U);
            likeItem.Comment.ParentId.Should().Be(1234U);
            likeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            likeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            likeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            likeItem.Comment.Spoiler.Should().BeFalse();
            likeItem.Comment.Review.Should().BeFalse();
            likeItem.Comment.Replies.Should().Be(1);
            likeItem.Comment.Likes.Should().Be(2);
            likeItem.Comment.UserStats.Should().NotBeNull();
            likeItem.Comment.UserStats.Rating.Should().Be(8);
            likeItem.Comment.UserStats.PlayCount.Should().Be(1);
            likeItem.Comment.UserStats.CompletedCount.Should().Be(1);
            likeItem.Comment.User.Should().NotBeNull();
            likeItem.Comment.User.Username.Should().Be("sean");
            likeItem.Comment.User.IsPrivate.Should().BeFalse();
            likeItem.Comment.User.Name.Should().Be("Sean Rudford");
            likeItem.Comment.User.IsVIP.Should().BeTrue();
            likeItem.Comment.User.IsVIP_EP.Should().BeTrue();
            likeItem.Comment.User.Ids.Should().NotBeNull();
            likeItem.Comment.User.Ids.Slug.Should().Be("sean");
            likeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItem_With_Type_Episode_From_Json()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();
            var likeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON) as TraktUserLikeItem;

            likeItem.Should().NotBeNull();
            likeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            likeItem.Type.Should().Be(TraktUserLikeType.List);
            likeItem.List.Should().NotBeNull();
            likeItem.List.Name.Should().Be("Star Wars in machete order");
            likeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            likeItem.List.Privacy.Should().Be(TraktListPrivacy.Public);
            likeItem.List.DisplayNumbers.Should().BeTrue();
            likeItem.List.AllowComments.Should().BeFalse();
            likeItem.List.SortBy.Should().Be(TraktSortBy.Rank);
            likeItem.List.SortHow.Should().Be(TraktSortHow.Ascending);
            likeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            likeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            likeItem.List.ItemCount.Should().Be(5);
            likeItem.List.CommentCount.Should().Be(1);
            likeItem.List.Likes.Should().Be(2);
            likeItem.List.Ids.Should().NotBeNull();
            likeItem.List.Ids.Trakt.Should().Be(55);
            likeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            likeItem.List.User.Should().NotBeNull();
            likeItem.List.User.Username.Should().Be("sean");
            likeItem.List.User.IsPrivate.Should().BeFalse();
            likeItem.List.User.Name.Should().Be("Sean Rudford");
            likeItem.List.User.IsVIP.Should().BeTrue();
            likeItem.List.User.IsVIP_EP.Should().BeFalse();
            likeItem.List.User.Ids.Should().NotBeNull();
            likeItem.List.User.Ids.Slug.Should().Be("sean");
            likeItem.Comment.Should().BeNull();
        }

        private const string TYPE_COMMENT_JSON =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""comment"",
                ""comment"": {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_stats"": {
                    ""rating"": 8,
                    ""play_count"": 1,
                    ""completed_count"": 1
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";
    }
}
