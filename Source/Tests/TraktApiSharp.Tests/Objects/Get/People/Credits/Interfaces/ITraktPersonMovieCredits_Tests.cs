namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonMovieCredits_Tests
    {
        [Fact]
        public void Test_ITraktPersonMovieCredits_Is_Interface()
        {
            typeof(ITraktPersonMovieCredits).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonMovieCredits_Has_Cast_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCredits).GetProperties().FirstOrDefault(p => p.Name == "Cast");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPersonMovieCreditsCastItem>));
        }

        [Fact]
        public void Test_ITraktPersonMovieCredits_Has_Crew_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCredits).GetProperties().FirstOrDefault(p => p.Name == "Crew");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPersonMovieCreditsCrew));
        }
    }
}
