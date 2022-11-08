namespace TraktNet.Objects.Get.Tests.Ratings.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Ratings;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new RatingsItemObjectJsonReader();
            Func<Task<ITraktRatingsItem>> traktRatingItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktRatingItem.Should().ThrowAsync<ArgumentNullException>();
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
