namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCastMemberArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCastMemberArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktCastMemberArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktCastMember>));
        }
    }
}
