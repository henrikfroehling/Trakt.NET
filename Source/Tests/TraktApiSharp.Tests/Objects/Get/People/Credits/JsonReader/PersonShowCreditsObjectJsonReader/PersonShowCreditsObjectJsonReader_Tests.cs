namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PersonShowCreditsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PersonShowCreditsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPersonShowCredits>));
        }
    }
}
