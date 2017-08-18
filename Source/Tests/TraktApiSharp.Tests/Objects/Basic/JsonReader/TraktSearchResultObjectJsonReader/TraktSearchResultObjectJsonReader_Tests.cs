namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktSearchResultObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSearchResultObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSearchResultObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSearchResult>));
        }
    }
}
