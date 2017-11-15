namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.Json;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(default(string));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktListItem.Should().BeNull();
        }
    }
}
