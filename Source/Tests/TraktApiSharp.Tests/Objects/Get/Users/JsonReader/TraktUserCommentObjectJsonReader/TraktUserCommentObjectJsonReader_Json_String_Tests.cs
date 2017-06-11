namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktUserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(default(string));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktUserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserComment.Should().BeNull();
        }
    }
}
