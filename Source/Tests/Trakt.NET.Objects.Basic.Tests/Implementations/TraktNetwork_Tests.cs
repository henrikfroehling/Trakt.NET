namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktNetwork_Tests
    {
        [Fact]
        public void Test_TraktNetwork_Default_Constructor()
        {
            var traktNetwork = new TraktNetwork();

            traktNetwork.Name.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktNetwork_From_Json()
        {
            var jsonReader = new NetworkObjectJsonReader();
            var traktNetwork = await jsonReader.ReadObjectAsync(JSON) as TraktNetwork;

            traktNetwork.Should().NotBeNull();
            traktNetwork.Name.Should().Be("ABC(US)");
        }

        private const string JSON =
            @"{
                ""name"": ""ABC(US)""
              }";
    }
}
