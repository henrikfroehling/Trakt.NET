namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCastMemberObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCastMemberObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCastMemberObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCastMember>));
        }
    }
}
