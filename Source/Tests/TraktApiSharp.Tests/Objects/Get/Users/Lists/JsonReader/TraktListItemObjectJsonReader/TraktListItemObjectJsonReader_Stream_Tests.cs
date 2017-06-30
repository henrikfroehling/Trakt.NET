namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktListItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);
                traktListItem.Should().BeNull();
            }
        }
    }
}
