namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonShowCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_ITraktPersonShowCreditsCrewItem_Is_Interface()
        {
            typeof(ITraktPersonShowCreditsCrewItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonShowCreditsCrewItem_Has_Job_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCreditsCrewItem).GetProperties().FirstOrDefault(p => p.Name == "Job");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonShowCreditsCrewItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCreditsCrewItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
