namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);
                traktUserComment.Should().BeNull();
            }
        }
    }
}
