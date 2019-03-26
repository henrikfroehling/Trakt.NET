namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using TraktNet.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CommentLikeObjectJsonWriter_Tests
    {
        private readonly DateTime LIKED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_CommentLikeObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CommentLikeObjectJsonWriter();
            ITraktCommentLike traktCommentLike = new TraktCommentLike();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCommentLike);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CommentLikeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCommentLike);
                stringWriter.ToString().Should().Be(@"{}");
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_JsonWriter_Only_LikedAt_Property()
        {
            ITraktCommentLike traktCommentLike = new TraktCommentLike
            {
                LikedAt = LIKED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CommentLikeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCommentLike);
                stringWriter.ToString().Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_JsonWriter_Only_User_Property()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CommentLikeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCommentLike);
                stringWriter.ToString().Should().Be(@"{""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                                                    @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonWriter_WriteObject_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CommentLikeObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCommentLike);
                stringWriter.ToString().Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                                                    @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}");
            }
        }
    }
}
