namespace TraktApiSharp.Tests.Objects.Get.Users.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(default(string));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserComment.Should().BeNull();
        }
    }
}
