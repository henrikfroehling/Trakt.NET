namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();
            Func<Task<ITraktUserComment>> traktUserComment = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktUserComment.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktUserComment.Should().BeNull();
        }
    }
}
