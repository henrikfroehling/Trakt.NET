namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);
                traktComments.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(76957U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().NotBeNull();
                comments[0].User.Username.Should().Be("sean");
                comments[0].User.IsPrivate.Should().BeFalse();
                comments[0].User.Name.Should().Be("Sean Rudford");
                comments[0].User.IsVIP.Should().BeTrue();
                comments[0].User.IsVIP_EP.Should().BeTrue();
                comments[0].User.Ids.Should().NotBeNull();
                comments[0].User.Ids.Slug.Should().Be("sean");

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(76957U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().NotBeNull();
                comments[1].User.Username.Should().Be("sean");
                comments[1].User.IsPrivate.Should().BeFalse();
                comments[1].User.Name.Should().Be("Sean Rudford");
                comments[1].User.IsVIP.Should().BeTrue();
                comments[1].User.IsVIP_EP.Should().BeTrue();
                comments[1].User.Ids.Should().NotBeNull();
                comments[1].User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(76957U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().NotBeNull();
                comments[0].User.Username.Should().Be("sean");
                comments[0].User.IsPrivate.Should().BeFalse();
                comments[0].User.Name.Should().Be("Sean Rudford");
                comments[0].User.IsVIP.Should().BeTrue();
                comments[0].User.IsVIP_EP.Should().BeTrue();
                comments[0].User.Ids.Should().NotBeNull();
                comments[0].User.Ids.Slug.Should().Be("sean");

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(76957U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(76957U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().BeNull();

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(76957U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().NotBeNull();
                comments[1].User.Username.Should().Be("sean");
                comments[1].User.IsPrivate.Should().BeFalse();
                comments[1].User.Name.Should().Be("Sean Rudford");
                comments[1].User.IsVIP.Should().BeTrue();
                comments[1].User.IsVIP_EP.Should().BeTrue();
                comments[1].User.Ids.Should().NotBeNull();
                comments[1].User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(0U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().NotBeNull();
                comments[0].User.Username.Should().Be("sean");
                comments[0].User.IsPrivate.Should().BeFalse();
                comments[0].User.Name.Should().Be("Sean Rudford");
                comments[0].User.IsVIP.Should().BeTrue();
                comments[0].User.IsVIP_EP.Should().BeTrue();
                comments[0].User.Ids.Should().NotBeNull();
                comments[0].User.Ids.Slug.Should().Be("sean");

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(76957U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().NotBeNull();
                comments[1].User.Username.Should().Be("sean");
                comments[1].User.IsPrivate.Should().BeFalse();
                comments[1].User.Name.Should().Be("Sean Rudford");
                comments[1].User.IsVIP.Should().BeTrue();
                comments[1].User.IsVIP_EP.Should().BeTrue();
                comments[1].User.Ids.Should().NotBeNull();
                comments[1].User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(76957U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().NotBeNull();
                comments[0].User.Username.Should().Be("sean");
                comments[0].User.IsPrivate.Should().BeFalse();
                comments[0].User.Name.Should().Be("Sean Rudford");
                comments[0].User.IsVIP.Should().BeTrue();
                comments[0].User.IsVIP_EP.Should().BeTrue();
                comments[0].User.Ids.Should().NotBeNull();
                comments[0].User.Ids.Slug.Should().Be("sean");

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(0U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().NotBeNull();
                comments[1].User.Username.Should().Be("sean");
                comments[1].User.IsPrivate.Should().BeFalse();
                comments[1].User.Name.Should().Be("Sean Rudford");
                comments[1].User.IsVIP.Should().BeTrue();
                comments[1].User.IsVIP_EP.Should().BeTrue();
                comments[1].User.Ids.Should().NotBeNull();
                comments[1].User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);

                traktComments.Should().NotBeNull();
                ITraktComment[] comments = traktComments.ToArray();

                comments[0].Should().NotBeNull();
                comments[0].Id.Should().Be(0U);
                comments[0].ParentId.Should().Be(1234U);
                comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[0].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[0].Spoiler.Should().BeFalse();
                comments[0].Review.Should().BeFalse();
                comments[0].Replies.Should().Be(1);
                comments[0].Likes.Should().Be(2);
                comments[0].UserRating.Should().Be(7.3f);
                comments[0].User.Should().NotBeNull();
                comments[0].User.Username.Should().Be("sean");
                comments[0].User.IsPrivate.Should().BeFalse();
                comments[0].User.Name.Should().Be("Sean Rudford");
                comments[0].User.IsVIP.Should().BeTrue();
                comments[0].User.IsVIP_EP.Should().BeTrue();
                comments[0].User.Ids.Should().NotBeNull();
                comments[0].User.Ids.Slug.Should().Be("sean");

                comments[1].Should().NotBeNull();
                comments[1].Id.Should().Be(0U);
                comments[1].ParentId.Should().Be(1234U);
                comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                comments[1].Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                comments[1].Spoiler.Should().BeFalse();
                comments[1].Review.Should().BeFalse();
                comments[1].Replies.Should().Be(1);
                comments[1].Likes.Should().Be(2);
                comments[1].UserRating.Should().Be(7.3f);
                comments[1].User.Should().NotBeNull();
                comments[1].User.Username.Should().Be("sean");
                comments[1].User.IsPrivate.Should().BeFalse();
                comments[1].User.Name.Should().Be("Sean Rudford");
                comments[1].User.IsVIP.Should().BeTrue();
                comments[1].User.IsVIP_EP.Should().BeTrue();
                comments[1].User.Ids.Should().NotBeNull();
                comments[1].User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();
            IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(default(Stream));
            traktComments.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktComment>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktComment> traktComments = await jsonReader.ReadArrayAsync(stream);
                traktComments.Should().BeNull();
            }
        }
    }
}
