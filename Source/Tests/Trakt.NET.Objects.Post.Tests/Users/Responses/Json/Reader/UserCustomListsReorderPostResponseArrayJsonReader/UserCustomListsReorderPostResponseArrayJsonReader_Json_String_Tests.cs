namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserCustomListsReorderPostResponseArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktUserCustomListsReorderPostResponses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().Be(6);
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().Be(6);
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().Be(6);
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().BeNull();
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().BeNull();
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().Be(6);
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().Be(6);
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().BeNull();
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().BeNull();
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().Be(6);
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktUserCustomListsReorderPostResponses.Should().NotBeNull();
            ITraktUserCustomListsReorderPostResponse[] userCustomListsReorderPosts = traktUserCustomListsReorderPostResponses.ToArray();

            userCustomListsReorderPosts[0].Should().NotBeNull();
            userCustomListsReorderPosts[0].Updated.Should().BeNull();
            userCustomListsReorderPosts[0].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[0].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            userCustomListsReorderPosts[1].Should().NotBeNull();
            userCustomListsReorderPosts[1].Updated.Should().BeNull();
            userCustomListsReorderPosts[1].SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPosts[1].SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public void Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            Func<Task<IEnumerable<ITraktUserCustomListsReorderPostResponse>>> traktUserCustomListsReorderPostResponses = () => traktJsonReader.ReadArrayAsync(default(string));
            traktUserCustomListsReorderPostResponses.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(string.Empty);
            traktUserCustomListsReorderPostResponses.Should().BeNull();
        }
    }
}
