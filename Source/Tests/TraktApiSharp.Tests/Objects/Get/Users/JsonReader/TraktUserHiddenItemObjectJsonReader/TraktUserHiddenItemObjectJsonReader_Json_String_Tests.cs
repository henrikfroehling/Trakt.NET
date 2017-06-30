namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktUserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(default(string));
            traktUserHiddenItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktUserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserHiddenItem.Should().BeNull();
        }
    }
}
