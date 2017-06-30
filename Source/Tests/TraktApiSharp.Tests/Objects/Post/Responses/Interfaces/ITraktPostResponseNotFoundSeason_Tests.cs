namespace TraktApiSharp.Tests.Objects.Post.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.Interfaces")]
    public class ITraktPostResponseNotFoundSeason_Tests
    {
        [Fact]
        public void Test_ITraktPostResponseNotFoundSeason_Is_Interface()
        {
            typeof(ITraktPostResponseNotFoundSeason).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostResponseNotFoundSeason_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPostResponseNotFoundSeason).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeasonIds));
        }
    }
}
