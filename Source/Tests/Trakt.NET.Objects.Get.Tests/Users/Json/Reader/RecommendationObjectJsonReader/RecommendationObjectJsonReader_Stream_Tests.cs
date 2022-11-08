namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class RecommendationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new RecommendationObjectJsonReader();
            Func<Task<ITraktRecommendation>> traktRecommendation = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktRecommendation.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            using var stream = string.Empty.ToStream();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(stream);
            traktRecommendation.Should().BeNull();
        }
    }
}
