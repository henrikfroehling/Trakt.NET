namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktErrorObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktErrorObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktErrorObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktError>));
        }
    }
}
