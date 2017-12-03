namespace TraktApiSharp.Tests.Objects.Get.Ratings.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(string));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktRatingItem.Should().BeNull();
        }
    }
}
