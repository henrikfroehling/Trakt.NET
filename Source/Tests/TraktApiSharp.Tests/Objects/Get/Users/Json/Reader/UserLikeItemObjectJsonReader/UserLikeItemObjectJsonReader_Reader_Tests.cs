namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktUserLikeItem.Should().BeNull();
            }
        }
    }
}
