namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class SharingTextObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await traktJsonReader.ReadObjectAsync(default(string));
            userSharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SharingTextObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSharingText = await traktJsonReader.ReadObjectAsync(jsonReader);
                userSharingText.Should().BeNull();
            }
        }
    }
}
