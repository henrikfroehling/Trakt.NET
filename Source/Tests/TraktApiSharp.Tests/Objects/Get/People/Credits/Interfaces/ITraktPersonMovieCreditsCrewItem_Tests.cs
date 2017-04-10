namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonMovieCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_ITraktPersonMovieCreditsCrewItem_Is_Interface()
        {
            typeof(ITraktPersonMovieCreditsCrewItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonMovieCreditsCrewItem_Has_Job_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCreditsCrewItem).GetProperties().FirstOrDefault(p => p.Name == "Job");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonMovieCreditsCrewItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCreditsCrewItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
