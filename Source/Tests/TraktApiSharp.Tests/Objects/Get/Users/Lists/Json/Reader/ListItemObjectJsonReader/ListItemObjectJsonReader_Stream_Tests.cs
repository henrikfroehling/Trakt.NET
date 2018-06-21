namespace TraktNet.Tests.Objects.Get.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);
                traktListItem.Should().BeNull();
            }
        }
    }
}
