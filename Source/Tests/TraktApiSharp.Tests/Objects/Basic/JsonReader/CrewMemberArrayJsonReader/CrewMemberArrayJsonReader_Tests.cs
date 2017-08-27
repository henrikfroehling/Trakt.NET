namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CrewMemberArrayJsonReader_Tests
    {
        [Fact]
        public void Test_CrewMemberArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(CrewMemberArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktCrewMember>));
        }
    }
}
