namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktRating_Tests
    {
        [Fact]
        public void Test_ITraktRating_Is_Interface()
        {
            typeof(ITraktRating).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRating_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktRating).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktRating_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktRating).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktRating_Has_Distribution_Property()
        {
            var propertyInfo = typeof(ITraktRating).GetProperties().FirstOrDefault(p => p.Name == "Distribution");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IDictionary<string, int>));
        }
    }
}
