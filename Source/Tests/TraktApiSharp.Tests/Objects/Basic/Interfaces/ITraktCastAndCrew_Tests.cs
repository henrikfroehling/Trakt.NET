namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktCastAndCrew_Tests
    {
        [Fact]
        public void Test_ITraktCastAndCrew_Is_Interface()
        {
            typeof(ITraktCastAndCrew).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCastAndCrew_Has_Cast_Property()
        {
            var propertyInfo = typeof(ITraktCastAndCrew).GetProperties().FirstOrDefault(p => p.Name == "Cast");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCastMember>));
        }

        [Fact]
        public void Test_ITraktCastAndCrew_Has_Crew_Property()
        {
            var propertyInfo = typeof(ITraktCastAndCrew).GetProperties().FirstOrDefault(p => p.Name == "Crew");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktCrew));
        }
    }
}
