namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.JsonReader")]
    public partial class ListItemsReorderPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            Func<Task<ITraktListItemsReorderPostResponse>> listItemsReorderPostResponse = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await listItemsReorderPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                listItemsReorderPostResponse.Should().BeNull();
            }
        }
    }
}
