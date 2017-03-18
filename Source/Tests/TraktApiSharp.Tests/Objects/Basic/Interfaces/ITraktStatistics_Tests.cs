namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktStatistics_Tests
    {
        [Fact]
        public void Test_ITraktStatistics_Is_Interface()
        {
            typeof(ITraktStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Watchers_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Watchers");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Plays_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Plays");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Collectors_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Collectors");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_CollectedEpisodes_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "CollectedEpisodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Comments_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Comments");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Lists_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Lists");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktStatistics_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktStatistics).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
