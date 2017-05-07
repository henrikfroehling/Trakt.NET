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
    public partial class ITraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktRatingsItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktRatingsItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);
                traktRatingItem.Should().BeNull();
            }
        }
    }
}
