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
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserLikeItem = await jsonReader.ReadObjectAsync(stream);
                traktUserLikeItem.Should().BeNull();
            }
        }
    }
}
