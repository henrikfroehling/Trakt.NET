namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.People;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktCastMember_Tests
    {
        [Fact]
        public void Test_ITraktCastMember_Is_Interface()
        {
            typeof(ITraktCastMember).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCastMember_Has_Character_Property()
        {
            var propertyInfo = typeof(ITraktCastMember).GetProperties().FirstOrDefault(p => p.Name == "Character");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktCastMember_Has_Person_Property()
        {
            var propertyInfo = typeof(ITraktCastMember).GetProperties().FirstOrDefault(p => p.Name == "Person");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPerson));
        }
    }
}
