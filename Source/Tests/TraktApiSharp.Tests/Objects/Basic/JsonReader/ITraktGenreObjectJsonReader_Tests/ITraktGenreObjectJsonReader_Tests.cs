namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktGenreObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktGenreObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktGenreObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktGenre>));
        }
    }
}
