namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonShowCreditsCastItem_Tests
    {
        [Fact]
        public void Test_ITraktPersonShowCreditsCastItem_Is_Interface()
        {
            typeof(ITraktPersonShowCreditsCastItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonShowCreditsCastItem_Has_Character_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCreditsCastItem).GetProperties().FirstOrDefault(p => p.Name == "Character");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonShowCreditsCastItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktPersonShowCreditsCastItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
