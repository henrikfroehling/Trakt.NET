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
    public partial class CommentArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CommentArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktComment>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktComment> traktComments = new List<TraktComment>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktComment>();
            string json = await traktJsonWriter.WriteArrayAsync(traktComments);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CommentArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktComment> traktComments = new List<ITraktComment>
            {
                new TraktComment
                {
                    Id = 76957U,
                    ParentId = 1234U,
                    CreatedAt = CREATED_UPDATED_AT,
                    UpdatedAt = CREATED_UPDATED_AT,
                    Comment = "I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.",
                    Spoiler = true,
                    Review = true,
                    Replies = 1,
                    Likes = 2,
                    UserRating = 7.3f,
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktComment>();
            string json = await traktJsonWriter.WriteArrayAsync(traktComments);
            json.Should().Be(@"[{""id"":76957,""parent_id"":1234," +
                             $"\"created_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""comment"":""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.""," +
                             @"""spoiler"":true,""review"":true,""replies"":1,""likes"":2,""user_rating"":7.3," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
        }

        [Fact]
        public async Task Test_CommentArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktComment> traktComments = new List<ITraktComment>
            {
                new TraktComment
                {
                    Id = 76957U,
                    ParentId = 1234U,
                    CreatedAt = CREATED_UPDATED_AT,
                    UpdatedAt = CREATED_UPDATED_AT,
                    Comment = "I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.",
                    Spoiler = true,
                    Review = true,
                    Replies = 1,
                    Likes = 2,
                    UserRating = 7.3f,
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
                new TraktComment
                {
                    Id = 76958U,
                    ParentId = 1234U,
                    CreatedAt = CREATED_UPDATED_AT,
                    UpdatedAt = CREATED_UPDATED_AT,
                    Comment = "I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.",
                    Spoiler = true,
                    Review = true,
                    Replies = 1,
                    Likes = 2,
                    UserRating = 7.3f,
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktComment>();
            string json = await traktJsonWriter.WriteArrayAsync(traktComments);
            json.Should().Be(@"[{""id"":76957,""parent_id"":1234," +
                             $"\"created_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""comment"":""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.""," +
                             @"""spoiler"":true,""review"":true,""replies"":1,""likes"":2,""user_rating"":7.3," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}," +
                             @"{""id"":76958,""parent_id"":1234," +
                             $"\"created_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{CREATED_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""comment"":""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.""," +
                             @"""spoiler"":true,""review"":true,""replies"":1,""likes"":2,""user_rating"":7.3," +
                             @"""user"":{""username"":""sean"",""private"":false,""ids"":{""slug"":""sean""}," +
                             @"""name"":""Sean Rudford"",""vip"":true,""vip_ep"":true}}]");
        }
    }
}
