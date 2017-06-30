namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktUserIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_TraktUserIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new TraktUserIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);

                userIds.Should().NotBeNull();
                userIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserIdsObjectJsonReader();

            var userIds = await jsonReader.ReadObjectAsync(default(Stream));
            userIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userIds = await jsonReader.ReadObjectAsync(stream);
                userIds.Should().BeNull();
            }
        }
    }
}
