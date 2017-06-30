namespace TraktApiSharp.Tests.Objects.Post.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.Interfaces")]
    public class ITraktPostResponseNotFoundEpisode_Tests
    {
        [Fact]
        public void Test_ITraktPostResponseNotFoundEpisode_Is_Interface()
        {
            typeof(ITraktPostResponseNotFoundEpisode).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostResponseNotFoundEpisode_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPostResponseNotFoundEpisode).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisodeIds));
        }
    }
}
