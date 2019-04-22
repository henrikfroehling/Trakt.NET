namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
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
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(76957U);
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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().Be(1234U);
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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().BeNull();
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().BeNull();
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().BeNull();
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().Be(1);
                traktComment.Likes.Should().BeNull();
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

                traktComment.Should().NotBeNull();
                traktComment.Id.Should().Be(0U);
                traktComment.ParentId.Should().BeNull();
                traktComment.CreatedAt.Should().Be(default(DateTime));
                traktComment.UpdatedAt.Should().BeNull();
                traktComment.Comment.Should().BeNull();
                traktComment.Spoiler.Should().BeFalse();
                traktComment.Review.Should().BeFalse();
                traktComment.Replies.Should().BeNull();
                traktComment.Likes.Should().Be(2);
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().Be(7.3f);
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
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
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
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
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);

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
                traktComment.UserRating.Should().BeNull();
                traktComment.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(default(Stream));
            traktComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CommentObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktComment = await jsonReader.ReadObjectAsync(stream);
                traktComment.Should().BeNull();
            }
        }
    }
}
