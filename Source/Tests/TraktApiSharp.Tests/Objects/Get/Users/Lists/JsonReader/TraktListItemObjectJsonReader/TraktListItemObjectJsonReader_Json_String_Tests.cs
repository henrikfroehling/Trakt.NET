namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(default(string));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktListItem.Should().BeNull();
        }
    }
}
