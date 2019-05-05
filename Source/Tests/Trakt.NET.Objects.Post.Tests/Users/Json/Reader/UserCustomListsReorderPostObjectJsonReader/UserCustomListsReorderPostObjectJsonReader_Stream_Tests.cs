namespace TraktNet.Objects.Post.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.JsonReader")]
    public partial class UserCustomListsReorderPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(stream);

                traktUserCustomListsReorderPost.Should().NotBeNull();
                traktUserCustomListsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
                traktUserCustomListsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(stream);

                traktUserCustomListsReorderPost.Should().NotBeNull();
                traktUserCustomListsReorderPost.Rank.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();
            var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktUserCustomListsReorderPost.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(stream);
                traktUserCustomListsReorderPost.Should().BeNull();
            }
        }
    }
}
