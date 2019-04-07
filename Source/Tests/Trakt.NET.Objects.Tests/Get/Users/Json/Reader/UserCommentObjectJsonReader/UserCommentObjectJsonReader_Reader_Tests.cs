namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserComment.Should().BeNull();
            }
        }
    }
}
