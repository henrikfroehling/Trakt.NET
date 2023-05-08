namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CommentLikeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCommentLikes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[0].User.Should().NotBeNull();
            commentLikes[0].User.Username.Should().Be("sean");
            commentLikes[0].User.IsPrivate.Should().BeFalse();
            commentLikes[0].User.Name.Should().Be("Sean Rudford");
            commentLikes[0].User.IsVIP.Should().BeTrue();
            commentLikes[0].User.IsVIP_EP.Should().BeFalse();
            commentLikes[0].User.Ids.Should().NotBeNull();
            commentLikes[0].User.Ids.Slug.Should().Be("sean");

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().NotBeNull();
            commentLikes[1].User.Username.Should().Be("sean");
            commentLikes[1].User.IsPrivate.Should().BeFalse();
            commentLikes[1].User.Name.Should().Be("Sean Rudford");
            commentLikes[1].User.IsVIP.Should().BeTrue();
            commentLikes[1].User.IsVIP_EP.Should().BeFalse();
            commentLikes[1].User.Ids.Should().NotBeNull();
            commentLikes[1].User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[0].User.Should().NotBeNull();
            commentLikes[0].User.Username.Should().Be("sean");
            commentLikes[0].User.IsPrivate.Should().BeFalse();
            commentLikes[0].User.Name.Should().Be("Sean Rudford");
            commentLikes[0].User.IsVIP.Should().BeTrue();
            commentLikes[0].User.IsVIP_EP.Should().BeFalse();
            commentLikes[0].User.Ids.Should().NotBeNull();
            commentLikes[0].User.Ids.Slug.Should().Be("sean");

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[0].User.Should().BeNull();

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().NotBeNull();
            commentLikes[1].User.Username.Should().Be("sean");
            commentLikes[1].User.IsPrivate.Should().BeFalse();
            commentLikes[1].User.Name.Should().Be("Sean Rudford");
            commentLikes[1].User.IsVIP.Should().BeTrue();
            commentLikes[1].User.IsVIP_EP.Should().BeFalse();
            commentLikes[1].User.Ids.Should().NotBeNull();
            commentLikes[1].User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().BeNull();
            commentLikes[0].User.Should().NotBeNull();
            commentLikes[0].User.Username.Should().Be("sean");
            commentLikes[0].User.IsPrivate.Should().BeFalse();
            commentLikes[0].User.Name.Should().Be("Sean Rudford");
            commentLikes[0].User.IsVIP.Should().BeTrue();
            commentLikes[0].User.IsVIP_EP.Should().BeFalse();
            commentLikes[0].User.Ids.Should().NotBeNull();
            commentLikes[0].User.Ids.Slug.Should().Be("sean");

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().NotBeNull();
            commentLikes[1].User.Username.Should().Be("sean");
            commentLikes[1].User.IsPrivate.Should().BeFalse();
            commentLikes[1].User.Name.Should().Be("Sean Rudford");
            commentLikes[1].User.IsVIP.Should().BeTrue();
            commentLikes[1].User.IsVIP_EP.Should().BeFalse();
            commentLikes[1].User.Ids.Should().NotBeNull();
            commentLikes[1].User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[0].User.Should().NotBeNull();
            commentLikes[0].User.Username.Should().Be("sean");
            commentLikes[0].User.IsPrivate.Should().BeFalse();
            commentLikes[0].User.Name.Should().Be("Sean Rudford");
            commentLikes[0].User.IsVIP.Should().BeTrue();
            commentLikes[0].User.IsVIP_EP.Should().BeFalse();
            commentLikes[0].User.Ids.Should().NotBeNull();
            commentLikes[0].User.Ids.Slug.Should().Be("sean");

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktCommentLikes.Should().NotBeNull();
            ITraktCommentLike[] commentLikes = traktCommentLikes.ToArray();

            commentLikes[0].Should().NotBeNull();
            commentLikes[0].LikedAt.Should().BeNull();
            commentLikes[0].User.Should().NotBeNull();
            commentLikes[0].User.Username.Should().Be("sean");
            commentLikes[0].User.IsPrivate.Should().BeFalse();
            commentLikes[0].User.Name.Should().Be("Sean Rudford");
            commentLikes[0].User.IsVIP.Should().BeTrue();
            commentLikes[0].User.IsVIP_EP.Should().BeFalse();
            commentLikes[0].User.Ids.Should().NotBeNull();
            commentLikes[0].User.Ids.Slug.Should().Be("sean");

            commentLikes[1].Should().NotBeNull();
            commentLikes[1].LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            commentLikes[1].User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            Func<Task<IList<ITraktCommentLike>>> traktCommentLikes = () => traktJsonReader.ReadArrayAsync(default(string));
            await traktCommentLikes.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCommentLike>();
            IList<ITraktCommentLike> traktCommentLikes = await traktJsonReader.ReadArrayAsync(string.Empty);
            traktCommentLikes.Should().BeNull();
        }
    }
}
