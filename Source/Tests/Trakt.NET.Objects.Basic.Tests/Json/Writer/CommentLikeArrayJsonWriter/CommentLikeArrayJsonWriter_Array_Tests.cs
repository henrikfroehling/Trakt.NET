namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CommentLikeArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCommentLike> traktCommentLikes = new List<TraktCommentLike>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentLikes);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentLikes);
            json.Should().Be($"[{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCommentLike>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCommentLikes);
            json.Should().Be($"[{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}," +
                             $"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
        }
    }
}
