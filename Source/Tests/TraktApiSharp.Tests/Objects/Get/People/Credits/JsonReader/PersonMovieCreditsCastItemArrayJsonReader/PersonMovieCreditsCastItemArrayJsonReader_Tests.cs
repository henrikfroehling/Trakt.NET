namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PersonMovieCreditsCastItemArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PersonMovieCreditsCastItemArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPersonMovieCreditsCastItem>));
        }
    }
}
