namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktTranslation_Tests
    {
        [Fact]
        public void Test_ITraktTranslation_Is_Interface()
        {
            typeof(ITraktTranslation).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktTranslation_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktTranslation).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktTranslation_Has_Overview_Property()
        {
            var propertyInfo = typeof(ITraktTranslation).GetProperties().FirstOrDefault(p => p.Name == "Overview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktTranslation_Has_LanguageCode_Property()
        {
            var propertyInfo = typeof(ITraktTranslation).GetProperties().FirstOrDefault(p => p.Name == "LanguageCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
