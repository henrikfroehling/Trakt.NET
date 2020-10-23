namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentLikeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentLike.Should().NotBeNull();
                traktCommentLike.LikedAt.Should().BeNull();
                traktCommentLike.User.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();
            Func<Task<ITraktCommentLike>> traktCommentLike = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCommentLike.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentLikeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CommentLikeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCommentLike traktCommentLike = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCommentLike.Should().BeNull();
            }
        }
    }
}
