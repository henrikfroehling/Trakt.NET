namespace Trakt.NET.Objects.Tests.Post.Users.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.JsonReader")]
    public partial class UserCustomListsReorderPostArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);
                traktUserCustomListsReorderPosts.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().BeNull();

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().BeNull();

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
                userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);

                traktUserCustomListsReorderPosts.Should().NotBeNull();
                ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

                userCustomListsReorderPosts[0].Should().NotBeNull();
                userCustomListsReorderPosts[0].Rank.Should().BeNull();

                userCustomListsReorderPosts[1].Should().NotBeNull();
                userCustomListsReorderPosts[1].Rank.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktUserCustomListsReorderPosts.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(stream);
                traktUserCustomListsReorderPosts.Should().BeNull();
            }
        }
    }
}
