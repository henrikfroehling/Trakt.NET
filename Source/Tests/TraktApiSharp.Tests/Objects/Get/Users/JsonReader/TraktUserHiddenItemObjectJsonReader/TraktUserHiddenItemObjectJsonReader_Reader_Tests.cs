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
    public partial class TraktUserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserHiddenItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserHiddenItem.Should().BeNull();
            }
        }
    }
}
