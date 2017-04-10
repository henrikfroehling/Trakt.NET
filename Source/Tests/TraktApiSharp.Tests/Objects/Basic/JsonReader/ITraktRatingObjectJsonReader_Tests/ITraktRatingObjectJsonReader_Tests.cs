namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktRatingObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktRatingObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktRatingObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktRating>));
        }
    }
}
