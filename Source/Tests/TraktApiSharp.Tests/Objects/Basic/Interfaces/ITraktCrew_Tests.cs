namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktCrew_Tests
    {
        [Fact]
        public void Test_ITraktCrew_Is_Interface()
        {
            typeof(ITraktCrew).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCrew_Has_Production_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Production");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Art_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Art");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Crew_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Crew");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_CostumeAndMakeup_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "CostumeAndMakeup");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Directing_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Directing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Writing_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Writing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Sound_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Sound");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Camera_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Camera");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Lighting_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Lighting");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_VisualEffects_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "VisualEffects");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }

        [Fact]
        public void Test_ITraktCrew_Has_Editing_Property()
        {
            var propertyInfo = typeof(ITraktCrew).GetProperties().FirstOrDefault(p => p.Name == "Editing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCrewMember>));
        }
    }
}
