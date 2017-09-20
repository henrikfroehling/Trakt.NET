namespace TraktApiSharp.Tests.Objects.Basic.JsonReader.NetworkArrayJsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkArrayJsonReader_Tests
    {
        [Fact]
        public void Test_NetworkArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(NetworkArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktNetwork>));
        }
    }
}
