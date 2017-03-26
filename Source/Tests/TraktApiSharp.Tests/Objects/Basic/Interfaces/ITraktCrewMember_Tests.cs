namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.People;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktCrewMember_Tests
    {
        [Fact]
        public void Test_ITraktCrewMember_Is_Interface()
        {
            typeof(ITraktCrewMember).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCrewMember_Has_Job_Property()
        {
            var propertyInfo = typeof(ITraktCrewMember).GetProperties().FirstOrDefault(p => p.Name == "Job");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktCrewMember_Has_Person_Property()
        {
            var propertyInfo = typeof(ITraktCrewMember).GetProperties().FirstOrDefault(p => p.Name == "Person");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPerson));
        }
    }
}
