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
    public partial class TraktUserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCommentObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserCommentObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);
                traktUserComment.Should().BeNull();
            }
        }
    }
}
