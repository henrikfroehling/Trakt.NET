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
    public partial class TraktUserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserLikeItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserLikeItem.Should().BeNull();
            }
        }
    }
}
