namespace TraktNet.Objects.Get.Tests.Seasons.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Seasons.Implementations")]
    public class TraktSeasonTranslation_Tests
    {
        [Fact]
        public void Test_TraktSeasonTranslation_Default_Constructor()
        {
            var seasonTranslation = new TraktSeasonTranslation();

            seasonTranslation.Title.Should().BeNullOrEmpty();
            seasonTranslation.Overview.Should().BeNullOrEmpty();
            seasonTranslation.LanguageCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktSeasonTranslation_From_Json()
        {
            var jsonReader = new SeasonTranslationObjectJsonReader();
            var seasonTranslation = await jsonReader.ReadObjectAsync(JSON) as TraktSeasonTranslation;

            seasonTranslation.Should().NotBeNull();
            seasonTranslation.Title.Should().Be("Sesong 1");
            seasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            seasonTranslation.LanguageCode.Should().Be("no");
        }

        private const string JSON =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no""
              }";
    }
}
