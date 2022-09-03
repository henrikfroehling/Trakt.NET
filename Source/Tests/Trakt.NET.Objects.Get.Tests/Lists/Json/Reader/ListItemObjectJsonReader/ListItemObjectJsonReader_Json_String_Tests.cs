namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ListItemObjectJsonReader();
            Func<Task<ITraktListItem>> traktListItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktListItem.Should().ThrowAsync<ArgumentNullException>();
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
