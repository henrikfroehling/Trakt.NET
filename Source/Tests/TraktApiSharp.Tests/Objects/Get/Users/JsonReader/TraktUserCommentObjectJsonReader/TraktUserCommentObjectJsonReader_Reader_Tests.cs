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
    public partial class TraktUserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserCommentObjectJsonReader();

            var traktUserComment = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserCommentObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserComment.Should().BeNull();
            }
        }
    }
}
