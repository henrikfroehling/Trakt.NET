namespace TraktNet.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktNetwork_Tests
    {
        [Fact]
        public void Test_TraktNetwork_Default_Constructor()
        {
            var traktNetwork = new TraktNetwork();

            traktNetwork.Network.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktNetwork_From_Json()
        {
            var jsonReader = new NetworkObjectJsonReader();
            var traktNetwork = await jsonReader.ReadObjectAsync(JSON) as TraktNetwork;

            traktNetwork.Should().NotBeNull();
            traktNetwork.Network.Should().Be("ABC(US)");
        }

        private const string JSON =
            @"{
                ""network"": ""ABC(US)""
              }";
    }
}
