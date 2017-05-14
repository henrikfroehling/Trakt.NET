namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class TraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(string));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktRatingItem.Should().BeNull();
        }
    }
}
