namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktComment_Tests
    {
        [Fact]
        public void Test_TraktComment_Default_Constructor()
        {
            var traktComment = new TraktComment();

            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktComment_From_Json()
        {
            var jsonReader = new CommentObjectJsonReader();
            var traktComment = await jsonReader.ReadObjectAsync(JSON) as TraktComment;

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        private const string JSON =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_rating"": 7.3,
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
              }";
    }
}
