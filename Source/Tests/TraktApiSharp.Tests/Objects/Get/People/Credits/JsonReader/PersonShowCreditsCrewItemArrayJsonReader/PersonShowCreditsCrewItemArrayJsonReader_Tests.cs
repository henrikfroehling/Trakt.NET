namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PersonShowCreditsCrewItemArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PersonShowCreditsCrewItemArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPersonShowCreditsCrewItem>));
        }
    }
}
