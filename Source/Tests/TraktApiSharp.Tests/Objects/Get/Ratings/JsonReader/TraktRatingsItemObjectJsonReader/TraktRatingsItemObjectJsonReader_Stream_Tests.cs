namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class TraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktRatingsItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);
                traktRatingItem.Should().BeNull();
            }
        }
    }
}
