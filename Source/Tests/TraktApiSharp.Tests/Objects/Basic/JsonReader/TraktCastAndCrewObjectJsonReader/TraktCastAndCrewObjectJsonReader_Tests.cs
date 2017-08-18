namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCastAndCrewObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCastAndCrewObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCastAndCrewObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCastAndCrew>));
        }
    }
}
