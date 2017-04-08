namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktImageObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktImageObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktImageObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktImage>));
        }
    }
}
