namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CastMemberObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CastMemberObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCastMember>));
        }
    }
}
