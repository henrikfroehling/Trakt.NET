namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktImageObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktImageObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktImageObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktImage>));
        }
    }
}
