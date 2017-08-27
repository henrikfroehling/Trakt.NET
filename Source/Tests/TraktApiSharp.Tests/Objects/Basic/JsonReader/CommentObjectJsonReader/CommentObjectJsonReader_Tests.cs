namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CommentObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CommentObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktComment>));
        }
    }
}
