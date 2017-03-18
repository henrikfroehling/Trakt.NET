namespace TraktApiSharp.Tests.Objects.Basic
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktGenre_Tests
    {
        [Fact]
        public void Test_ITraktGenre_Is_Interface()
        {
            typeof(ITraktGenre).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktGenre_Has_Name_Property()
        {
            var propertyInfo = typeof(ITraktGenre).GetProperties().FirstOrDefault(p => p.Name == "Name");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktGenre_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktGenre).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktGenre_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktGenre).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktGenreType));
        }
    }
}
