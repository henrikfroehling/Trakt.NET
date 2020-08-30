namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
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
            traktNetwork.Name.Should().Be("ABC(US)");
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktNetwork.Should().NotBeNull();
            traktNetwork.Name.Should().BeNull();
        }

        [Fact]
        public void Test_NetworkObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new NetworkObjectJsonReader();
            Func<Task<ITraktNetwork>> traktNetwork = () => jsonReader.ReadObjectAsync(default(string));
            traktNetwork.Should().Throw<ArgumentNullException>();
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
