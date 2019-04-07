namespace TraktNet.Objects.Tests.Basic.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCommentLike_Tests
    {
        [Fact]
        public void Test_TraktCommentLike_Default_Constructor()
        {
            var traktCommentLike = new TraktCommentLike();

            traktCommentLike.LikedAt.Should().BeNull();
            traktCommentLike.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCommentLike_From_Json()
        {
            var jsonReader = new CommentLikeObjectJsonReader();
            var traktCommentLike = await jsonReader.ReadObjectAsync(JSON) as TraktCommentLike;

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentLike.User.Should().NotBeNull();
            traktCommentLike.User.Username.Should().Be("sean");
            traktCommentLike.User.IsPrivate.Should().BeFalse();
            traktCommentLike.User.Name.Should().Be("Sean Rudford");
            traktCommentLike.User.IsVIP.Should().BeTrue();
            traktCommentLike.User.IsVIP_EP.Should().BeFalse();
            traktCommentLike.User.Ids.Should().NotBeNull();
            traktCommentLike.User.Ids.Slug.Should().Be("sean");
        }

        private const string JSON =
            @"{
                ""liked_at"": ""2014-10-11T17:00:54.000Z"",
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
              }";
    }
}
