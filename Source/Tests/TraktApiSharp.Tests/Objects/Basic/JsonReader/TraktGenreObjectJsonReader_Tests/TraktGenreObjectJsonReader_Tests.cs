namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktGenreObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktGenreObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktGenreObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktGenre>));
        }
    }
}
