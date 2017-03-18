namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMostAnticipatedMovie_Tests
    {
        [Fact]
        public void Test_ITraktMostAnticipatedMovie_Is_Interface()
        {
            typeof(ITraktMostAnticipatedMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktMostAnticipatedMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovie_Has_ListCount_Property()
        {
            var propertyInfo = typeof(ITraktMostAnticipatedMovie).GetProperties().FirstOrDefault(p => p.Name == "ListCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktMostAnticipatedMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
