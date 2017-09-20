namespace TraktApiSharp.Tests.Objects.Basic.JsonReader.NetworkObjectJsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkObjectJsonReader_Tests
    {
        [Fact]
        public void Test_NetworkObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(NetworkObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktNetwork>));
        }
    }
}
