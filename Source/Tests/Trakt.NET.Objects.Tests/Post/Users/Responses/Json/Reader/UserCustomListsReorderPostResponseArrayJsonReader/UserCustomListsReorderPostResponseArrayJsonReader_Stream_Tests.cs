namespace TraktNet.Objects.Tests.Post.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserCustomListsReorderPostResponseArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);
                traktUserCustomListsReorderPostResponses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktUserCustomListsReorderPostResponses.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(stream);
                traktUserCustomListsReorderPostResponses.Should().BeNull();
            }
        }
    }
}
