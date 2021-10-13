namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentLikeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().BeNull();
            traktCommentLike.User.Should().NotBeNull();
            traktCommentLike.User.Username.Should().Be("sean");
            traktCommentLike.User.IsPrivate.Should().BeFalse();
            traktCommentLike.User.Name.Should().Be("Sean Rudford");
            traktCommentLike.User.IsVIP.Should().BeTrue();
            traktCommentLike.User.IsVIP_EP.Should().BeFalse();
            traktCommentLike.User.Ids.Should().NotBeNull();
            traktCommentLike.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentLike.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().BeNull();
            traktCommentLike.User.Should().NotBeNull();
            traktCommentLike.User.Username.Should().Be("sean");
            traktCommentLike.User.IsPrivate.Should().BeFalse();
            traktCommentLike.User.Name.Should().Be("Sean Rudford");
            traktCommentLike.User.IsVIP.Should().BeTrue();
            traktCommentLike.User.IsVIP_EP.Should().BeFalse();
            traktCommentLike.User.Ids.Should().NotBeNull();
            traktCommentLike.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentLike.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCommentLike.Should().NotBeNull();
            traktCommentLike.LikedAt.Should().BeNull();
            traktCommentLike.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            Func<Task<ITraktCommentLike>> traktCommentLike = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktCommentLike.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktCommentLike.Should().BeNull();
        }
    }
}
