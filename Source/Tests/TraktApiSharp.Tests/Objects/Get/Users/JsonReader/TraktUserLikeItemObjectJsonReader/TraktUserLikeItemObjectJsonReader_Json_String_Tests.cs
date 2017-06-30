namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(default(string));
            traktUserLikeItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserLikeItem.Should().BeNull();
        }
    }
}
