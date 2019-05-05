namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            var traktListItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktListItem.Should().BeNull();
            }
        }
    }
}
