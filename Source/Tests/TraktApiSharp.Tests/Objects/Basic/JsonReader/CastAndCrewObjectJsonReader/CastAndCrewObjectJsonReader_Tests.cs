namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastAndCrewObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CastAndCrewObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CastAndCrewObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCastAndCrew>));
        }
    }
}
