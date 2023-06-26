namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class NetworkIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(16U);
            traktNetworkIds.Tmdb.Should().Be(2U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(0U);
            traktNetworkIds.Tmdb.Should().Be(2U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(16U);
            traktNetworkIds.Tmdb.Should().Be(0U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(0U);
            traktNetworkIds.Tmdb.Should().Be(2U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(16U);
            traktNetworkIds.Tmdb.Should().Be(0U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktNetworkIds.Should().NotBeNull();
            traktNetworkIds.Trakt.Should().Be(0U);
            traktNetworkIds.Tmdb.Should().Be(0U);
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();
            Func<Task<ITraktNetworkIds>> traktNetworkIds = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktNetworkIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new NetworkIdsObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktNetworkIds = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktNetworkIds.Should().BeNull();
        }
    }
}
