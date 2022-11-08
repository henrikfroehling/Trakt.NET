namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonReader")]
    public partial class PersonSocialIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().Be("twitter-id");
            traktPersonSocialIds.Facebook.Should().Be("facebook-id");
            traktPersonSocialIds.Instagram.Should().Be("instagram-id");
            traktPersonSocialIds.Wikipedia.Should().Be("wikipedia-link");
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().BeNullOrEmpty();
            traktPersonSocialIds.Facebook.Should().BeNullOrEmpty();
            traktPersonSocialIds.Instagram.Should().BeNullOrEmpty();
            traktPersonSocialIds.Wikipedia.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();
            Func<Task<ITraktPersonSocialIds>> traktPersonSocialIds = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktPersonSocialIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktPersonSocialIds.Should().BeNull();
        }
    }
}
