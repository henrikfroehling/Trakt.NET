namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonReader")]
    public partial class PersonSocialIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonSocialIdsObjectJsonReader();

            var traktPersonSocialIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().Be("twitter-id");
            traktPersonSocialIds.Facebook.Should().Be("facebook-id");
            traktPersonSocialIds.Instagram.Should().Be("instagram-id");
            traktPersonSocialIds.Wikipedia.Should().Be("wikipedia-link");
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonSocialIdsObjectJsonReader();

            var traktPersonSocialIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().BeNullOrEmpty();
            traktPersonSocialIds.Facebook.Should().BeNullOrEmpty();
            traktPersonSocialIds.Instagram.Should().BeNullOrEmpty();
            traktPersonSocialIds.Wikipedia.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonSocialIdsObjectJsonReader();
            Func<Task<ITraktPersonSocialIds>> traktPersonSocialIds = () => jsonReader.ReadObjectAsync(default(string));
            await traktPersonSocialIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonSocialIdsObjectJsonReader();

            var traktPersonSocialIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktPersonSocialIds.Should().BeNull();
        }
    }
}
