namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PersonMovieCreditsCastItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PersonMovieCreditsCastItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPersonMovieCreditsCastItem>));
        }
    }
}
