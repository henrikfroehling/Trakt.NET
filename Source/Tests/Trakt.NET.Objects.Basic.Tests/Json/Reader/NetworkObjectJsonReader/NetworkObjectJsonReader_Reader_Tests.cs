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
    public partial class NetworkObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktNetwork.Should().NotBeNull();
                traktNetwork.Name.Should().Be("ABC(US)");
            }
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktNetwork.Should().NotBeNull();
                traktNetwork.Name.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new NetworkObjectJsonReader();
            Func<Task<ITraktNetwork>> traktNetwork = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktNetwork.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktNetwork.Should().BeNull();
            }
        }
    }
}
