namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class SharingTextObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().Be("I'm watching [item]");
            userSharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().BeNull();
            userSharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().Be("I'm watching [item]");
            userSharingText.Watched.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().BeNull();
            userSharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().Be("I'm watching [item]");
            userSharingText.Watched.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userSharingText.Should().NotBeNull();
            userSharingText.Watching.Should().BeNull();
            userSharingText.Watched.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(default(string));
            userSharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(string.Empty);
            userSharingText.Should().BeNull();
        }
    }
}
