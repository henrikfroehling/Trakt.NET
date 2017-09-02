namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_RatingsItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(RatingsItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktRatingsItem>));
        }
    }
}
