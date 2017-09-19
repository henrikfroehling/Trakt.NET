namespace TraktApiSharp.Tests.Objects.Basic.JsonReader.NetworkObjectJsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktNetwork.Should().NotBeNull();
            traktNetwork.Network.Should().Be("ABC(US)");
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktNetwork.Should().NotBeNull();
            traktNetwork.Network.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await jsonReader.ReadObjectAsync(default(string));
            traktNetwork.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await jsonReader.ReadObjectAsync(string.Empty);
            traktNetwork.Should().BeNull();
        }
    }
}
