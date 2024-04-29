namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().BeNull();
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().BeNull();
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().Be(2);
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
                traktComment.ParentId.Should().Be(1234U);
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().BeNull();
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().BeNull();
                traktComment.User.Should().NotBeNull();
                traktComment.User.Username.Should().Be("sean");
                traktComment.User.IsPrivate.Should().BeFalse();
                traktComment.User.Name.Should().Be("Sean Rudford");
                traktComment.User.IsVIP.Should().BeTrue();
                traktComment.User.IsVIP_EP.Should().BeTrue();
                traktComment.User.Ids.Should().NotBeNull();
                traktComment.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktComment.UserStats.Should().NotBeNull();
                traktComment.UserStats.Rating.Should().Be(8);
                traktComment.UserStats.PlayCount.Should().Be(1);
                traktComment.UserStats.CompletedCount.Should().Be(1);
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new CommentObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().BeNull();
                traktComment.UserStats.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CommentObjectJsonReader();
            Func<Task<ITraktComment>> traktComment = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktComment.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CommentObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktComment = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktComment.Should().BeNull();
        }
    }
}
