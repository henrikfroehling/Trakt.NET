namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentLikeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().BeNull();
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CommentLikeObjectJsonReader();
            Func<Task<ITraktCommentLike>> traktCommentLike = () => jsonReader.ReadObjectAsync(default(Stream));
            traktCommentLike.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CommentLikeObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                ITraktCommentLike traktCommentLike = await jsonReader.ReadObjectAsync(stream);
                traktCommentLike.Should().BeNull();
            }
        }
    }
}
