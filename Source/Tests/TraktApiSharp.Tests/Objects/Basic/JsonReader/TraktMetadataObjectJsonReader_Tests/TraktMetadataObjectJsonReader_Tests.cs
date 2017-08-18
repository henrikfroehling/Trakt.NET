namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktMetadataObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMetadataObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMetadataObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMetadata>));
        }
    }
}
