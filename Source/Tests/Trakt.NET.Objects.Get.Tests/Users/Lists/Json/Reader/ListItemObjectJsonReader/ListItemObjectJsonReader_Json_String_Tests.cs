namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ListItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ListItemObjectJsonReader();
            Func<Task<ITraktListItem>> traktListItem = () => jsonReader.ReadObjectAsync(default(string));
            traktListItem.Should().Throw<ArgumentNullException>();
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
