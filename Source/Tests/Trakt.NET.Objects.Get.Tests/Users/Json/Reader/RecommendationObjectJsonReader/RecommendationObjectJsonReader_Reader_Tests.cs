namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class RecommendationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_RecommendationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();
            Func<Task<ITraktRecommendation>> traktRecommendation = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktRecommendation.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendation.Should().BeNull();
        }
    }
}
