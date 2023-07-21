namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class FavoriteObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_FavoriteObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();
            Func<Task<ITraktFavorite>> traktFavorite = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktFavorite.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktFavorite.Should().BeNull();
        }
    }
}
