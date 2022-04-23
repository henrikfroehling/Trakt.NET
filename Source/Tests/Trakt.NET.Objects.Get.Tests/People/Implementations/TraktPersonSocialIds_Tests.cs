namespace TraktNet.Objects.Get.Tests.People.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Implementations")]
    public class TraktPersonSocialIds_Tests
    {
        [Fact]
        public void Test_TraktPersonSocialIds_Default_Constructor()
        {
            var personSocialIds = new TraktPersonSocialIds();

            personSocialIds.Twitter.Should().BeNullOrEmpty();
            personSocialIds.Facebook.Should().BeNullOrEmpty();
            personSocialIds.Instagram.Should().BeNullOrEmpty();
            personSocialIds.Wikipedia.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktPersonSocialIds_From_Json()
        {
            var jsonReader = new PersonSocialIdsObjectJsonReader();
            var personSocialIds = await jsonReader.ReadObjectAsync(JSON) as TraktPersonSocialIds;

            personSocialIds.Should().NotBeNull();
            personSocialIds.Twitter.Should().Be("twitter-id");
            personSocialIds.Facebook.Should().Be("facebook-id");
            personSocialIds.Instagram.Should().Be("instagram-id");
            personSocialIds.Wikipedia.Should().Be("wikipedia-link");
        }

        private const string JSON =
            @"{
                ""twitter"": ""twitter-id"",
                ""facebook"": ""facebook-id"",
                ""instagram"": ""instagram-id"",
                ""wikipedia"": ""wikipedia-link""
              }";
    }
}
