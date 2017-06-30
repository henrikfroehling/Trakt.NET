namespace TraktApiSharp.Tests.Objects.Post.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.Interfaces")]
    public class ITraktPostResponseNotFoundMovie_Tests
    {
        [Fact]
        public void Test_ITraktPostResponseNotFoundMovie_Is_Interface()
        {
            typeof(ITraktPostResponseNotFoundMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostResponseNotFoundMovie_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPostResponseNotFoundMovie).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovieIds));
        }
    }
}
