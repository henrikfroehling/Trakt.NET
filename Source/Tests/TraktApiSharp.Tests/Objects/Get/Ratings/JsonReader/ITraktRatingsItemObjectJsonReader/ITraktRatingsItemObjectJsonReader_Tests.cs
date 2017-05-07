namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class ITraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktRatingsItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktRatingsItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktRatingsItem>));
        }
    }
}
