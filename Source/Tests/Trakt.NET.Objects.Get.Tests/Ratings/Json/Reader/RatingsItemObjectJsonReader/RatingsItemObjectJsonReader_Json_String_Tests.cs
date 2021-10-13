namespace TraktNet.Objects.Get.Tests.Ratings.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Ratings;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RatingsItemObjectJsonReader();
            Func<Task<ITraktRatingsItem>> traktRatingItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktRatingItem.Should().ThrowAsync<ArgumentNullException>();
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
