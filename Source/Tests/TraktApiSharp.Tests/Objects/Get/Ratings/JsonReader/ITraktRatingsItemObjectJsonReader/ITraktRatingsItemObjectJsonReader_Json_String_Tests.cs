namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class ITraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktRatingsItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(string));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktRatingsItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktRatingItem.Should().BeNull();
        }
    }
}
