namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class MetadataObjectJsonReader_Tests
    {
        [Fact]
        public void Test_MetadataObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(MetadataObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMetadata>));
        }
    }
}
