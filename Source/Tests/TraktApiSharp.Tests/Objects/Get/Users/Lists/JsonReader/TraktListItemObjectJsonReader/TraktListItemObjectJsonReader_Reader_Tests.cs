namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktListItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktListItem.Should().BeNull();
            }
        }
    }
}
