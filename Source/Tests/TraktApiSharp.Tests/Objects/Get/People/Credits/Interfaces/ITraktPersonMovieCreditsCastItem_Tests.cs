namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Xunit;

    [Category("Objects.Get.People.Credits.Interfaces")]
    public class ITraktPersonMovieCreditsCastItemMovieCreditsCastItem_Tests
    {
        [Fact]
        public void Test_ITraktPersonMovieCreditsCastItem_Is_Interface()
        {
            typeof(ITraktPersonMovieCreditsCastItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonMovieCreditsCastItem_Has_Character_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCreditsCastItem).GetProperties().FirstOrDefault(p => p.Name == "Character");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonMovieCreditsCastItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktPersonMovieCreditsCastItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
