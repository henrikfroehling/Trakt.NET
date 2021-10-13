namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ListItemObjectJsonReader();
            Func<Task<ITraktListItem>> traktListItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktListItem.Should().ThrowAsync<ArgumentNullException>();
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
