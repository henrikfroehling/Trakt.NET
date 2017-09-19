namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktNetwork_Tests
    {
        [Fact]
        public void Test_TraktNetwork_Implements_ITraktNetwork_Interface()
        {
            typeof(TraktNetwork).GetInterfaces().Should().Contain(typeof(ITraktNetwork));
        }

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
