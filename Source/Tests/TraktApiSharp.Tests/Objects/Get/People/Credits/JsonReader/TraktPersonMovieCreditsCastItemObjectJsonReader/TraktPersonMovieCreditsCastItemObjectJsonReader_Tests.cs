namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class TraktPersonMovieCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCastItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPersonMovieCreditsCastItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPersonMovieCreditsCastItem>));
        }
    }
}
