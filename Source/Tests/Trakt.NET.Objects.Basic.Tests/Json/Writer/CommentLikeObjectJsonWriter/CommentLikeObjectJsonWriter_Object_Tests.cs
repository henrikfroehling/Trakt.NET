namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CommentLikeObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CommentLikeObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike();
            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentLike);
            json.Should().Be(@"{}");
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_Object_Only_LikedAt_Property()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike
            {
                LikedAt = LIKED_AT
            };

            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentLike);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_Object_Only_User_Property()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike
            {
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = true,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean"
                    }
                }
            };

            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentLike);
            json.Should().Be(@"{""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike
            {
                LikedAt = LIKED_AT,
                User = new TraktUser
                {
                    Username = "sean",
                    IsPrivate = false,
                    Name = "Sean Rudford",
                    IsVIP = true,
                    IsVIP_EP = true,
                    Ids = new TraktUserIds
                    {
                        Slug = "sean"
                    }
                }
            };

            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentLike);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
        }
    }
}
