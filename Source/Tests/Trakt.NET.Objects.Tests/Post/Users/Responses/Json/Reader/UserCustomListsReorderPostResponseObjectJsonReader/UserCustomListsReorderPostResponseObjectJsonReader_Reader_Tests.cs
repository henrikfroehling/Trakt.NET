namespace TraktNet.Objects.Tests.Post.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserCustomListsReorderPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserCustomListsReorderPostResponse.Should().NotBeNull();
                traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
                traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserCustomListsReorderPostResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserCustomListsReorderPostResponse.Should().BeNull();
            }
        }
    }
}
