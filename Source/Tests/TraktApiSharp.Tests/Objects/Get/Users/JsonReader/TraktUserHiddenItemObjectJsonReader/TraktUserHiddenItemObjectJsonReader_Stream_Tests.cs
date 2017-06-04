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
    public partial class TraktUserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktUserHiddenItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserHiddenItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);
                traktUserHiddenItem.Should().BeNull();
            }
        }
    }
}
