namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CommentLikeArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CommentLikeArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
            IEnumerable<ITraktCommentLike> traktCommentLikes = new List<TraktCommentLike>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCommentLikes);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktCommentLike> traktCommentLikes = new List<TraktCommentLike>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCommentLikes);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktCommentLike> traktCommentLikes = new List<ITraktCommentLike>
            {
                new TraktCommentLike
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCommentLikes);
                json.Should().Be($"[{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                                 @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
            }
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktCommentLike> traktCommentLikes = new List<ITraktCommentLike>
            {
                new TraktCommentLike
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
                },
                new TraktCommentLike
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
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCommentLikes);
                json.Should().Be($"[{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                                 @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}," +
                                 $"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                                 @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
            }
        }
    }
}
