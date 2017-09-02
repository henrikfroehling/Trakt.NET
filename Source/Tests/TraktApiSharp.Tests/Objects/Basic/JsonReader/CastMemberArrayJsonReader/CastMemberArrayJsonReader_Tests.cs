namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberArrayJsonReader_Tests
    {
        [Fact]
        public void Test_CastMemberArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(CastMemberArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktCastMember>));
        }
    }
}
