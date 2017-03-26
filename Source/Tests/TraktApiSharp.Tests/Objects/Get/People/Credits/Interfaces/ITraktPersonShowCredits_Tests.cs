namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonShowCredits_Tests
    {
        [Fact]
        public void Test_ITraktPersonShowCredits_Is_Interface()
        {
            typeof(ITraktPersonShowCredits).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonShowCredits_Has_Cast_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCredits).GetProperties().FirstOrDefault(p => p.Name == "Cast");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPersonShowCreditsCastItem>));
        }

        [Fact]
        public void Test_ITraktPersonShowCredits_Has_Crew_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCredits).GetProperties().FirstOrDefault(p => p.Name == "Crew");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPersonShowCreditsCrew));
        }
    }
}
