namespace TraktNet.Objects.Get.Tests.Ratings.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Ratings;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();
            Func<Task<ITraktRatingsItem>> traktRatingItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktRatingItem.Should().ThrowAsync<ArgumentNullException>();
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
