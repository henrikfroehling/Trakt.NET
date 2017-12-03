namespace TraktApiSharp.Tests.Objects.Get.Ratings.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);
                traktRatingItem.Should().BeNull();
            }
        }
    }
}
