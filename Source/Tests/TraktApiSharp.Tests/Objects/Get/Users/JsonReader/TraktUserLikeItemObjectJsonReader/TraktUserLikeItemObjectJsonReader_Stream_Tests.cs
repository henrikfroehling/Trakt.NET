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
    public partial class TraktUserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserLikeItem = await jsonReader.ReadObjectAsync(stream);
                traktUserLikeItem.Should().BeNull();
            }
        }
    }
}
