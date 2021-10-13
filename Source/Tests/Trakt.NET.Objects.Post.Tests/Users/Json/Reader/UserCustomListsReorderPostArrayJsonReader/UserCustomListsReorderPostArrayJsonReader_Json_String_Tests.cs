namespace TraktNet.Objects.Post.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Users;
    using Xunit;

    [Category("Objects.Post.Users.JsonReader")]
    public partial class UserCustomListsReorderPostArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktUserCustomListsReorderPosts.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().BeNull();

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[0].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().BeNull();

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().NotBeNull().And.HaveCount(7);
            userCustomListsReorderPosts[1].Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktUserCustomListsReorderPosts.Should().NotBeNull();
            ITraktUserCustomListsReorderPost[] userCustomListsReorderPosts = traktUserCustomListsReorderPosts.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Rank.Should().BeNull();

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            Func<Task<IEnumerable<ITraktUserCustomListsReorderPost>>> traktUserCustomListsReorderPosts = () => traktJsonReader.ReadArrayAsync(default(string));
            await traktUserCustomListsReorderPosts.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = await traktJsonReader.ReadArrayAsync(string.Empty);
            traktUserCustomListsReorderPosts.Should().BeNull();
        }
    }
}
