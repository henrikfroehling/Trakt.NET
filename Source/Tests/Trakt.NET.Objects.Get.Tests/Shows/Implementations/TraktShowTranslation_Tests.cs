namespace TraktNet.Objects.Get.Tests.Shows.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.Implementations")]
    public class TraktShowTranslation_Tests
    {
        [Fact]
        public void Test_TraktShowTranslation_Default_Constructor()
        {
            var showTranslation = new TraktShowTranslation();

            showTranslation.Title.Should().BeNull();
            showTranslation.Overview.Should().BeNull();
            showTranslation.LanguageCode.Should().BeNull();
            showTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowTranslation_From_Json()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();
            var showTranslation = await jsonReader.ReadObjectAsync(JSON) as TraktShowTranslation;

            showTranslation.Should().NotBeNull();
            showTranslation.Title.Should().Be("Game of Thrones");
            showTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            showTranslation.LanguageCode.Should().Be("de");
            showTranslation.CountryCode.Should().Be("us");
        }

        private const string JSON =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""country"": ""us""
              }";
    }
}
