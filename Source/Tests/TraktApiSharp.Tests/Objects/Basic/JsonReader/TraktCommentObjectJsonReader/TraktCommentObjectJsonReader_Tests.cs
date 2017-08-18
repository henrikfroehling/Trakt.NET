namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCommentObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCommentObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCommentObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktComment>));
        }
    }
}
