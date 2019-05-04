namespace Trakt.NET.Objects.Tests.Post.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktUserCustomListsReorderPostResponses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktUserCustomListsReorderPostResponses.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktUserCustomListsReorderPostResponses.Should().BeNull();
            }
        }
    }
}
