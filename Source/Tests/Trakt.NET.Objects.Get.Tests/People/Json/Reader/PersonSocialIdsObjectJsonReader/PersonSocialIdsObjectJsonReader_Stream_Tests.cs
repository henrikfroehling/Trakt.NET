namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonSocialIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using Stream stream = JSON_COMPLETE.ToStream();
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(stream);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().Be("twitter-id");
            traktPersonSocialIds.Facebook.Should().Be("facebook-id");
            traktPersonSocialIds.Instagram.Should().Be("instagram-id");
            traktPersonSocialIds.Wikipedia.Should().Be("wikipedia-link");
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using Stream stream = JSON_NOT_VALID.ToStream();
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(stream);

            traktPersonSocialIds.Should().NotBeNull();
            traktPersonSocialIds.Twitter.Should().BeNullOrEmpty();
            traktPersonSocialIds.Facebook.Should().BeNullOrEmpty();
            traktPersonSocialIds.Instagram.Should().BeNullOrEmpty();
            traktPersonSocialIds.Wikipedia.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();
            Func<Task<ITraktPersonSocialIds>> traktPersonSocialIds = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktPersonSocialIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonSocialIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new PersonSocialIdsObjectJsonReader();

            using Stream stream = string.Empty.ToStream();
            var traktPersonSocialIds = await traktJsonReader.ReadObjectAsync(stream);
            traktPersonSocialIds.Should().BeNull();
        }
    }
}
