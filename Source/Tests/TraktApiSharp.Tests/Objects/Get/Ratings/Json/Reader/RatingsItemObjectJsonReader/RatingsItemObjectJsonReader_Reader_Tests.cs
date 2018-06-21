namespace TraktNet.Tests.Objects.Get.Ratings.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktRatingItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktRatingItem.Should().BeNull();
            }
        }
    }
}
