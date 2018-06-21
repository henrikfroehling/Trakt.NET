namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class SharingTextObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().Be("I just watched [item]");
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().Be("I'm watching [item]");
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);

                userSharingText.Should().NotBeNull();
                userSharingText.Watching.Should().BeNull();
                userSharingText.Watched.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            var userSharingText = await jsonReader.ReadObjectAsync(default(Stream));
            userSharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingTextObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SharingTextObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userSharingText = await jsonReader.ReadObjectAsync(stream);
                userSharingText.Should().BeNull();
            }
        }
    }
}
