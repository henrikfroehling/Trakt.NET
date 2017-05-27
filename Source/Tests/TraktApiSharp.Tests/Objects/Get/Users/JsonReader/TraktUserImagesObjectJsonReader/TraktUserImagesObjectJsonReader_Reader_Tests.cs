namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserImagesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserImagesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktUserImagesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().NotBeNull();
                userImages.Avatar.Full.Should().Be("https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif");
            }
        }

        [Fact]
        public async Task Test_TraktUserImagesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new TraktUserImagesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);

                userImages.Should().NotBeNull();
                userImages.Avatar.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserImagesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserImagesObjectJsonReader();

            var userImages = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userImages.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserImagesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserImagesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userImages = await traktJsonReader.ReadObjectAsync(jsonReader);
                userImages.Should().BeNull();
            }
        }
    }
}
