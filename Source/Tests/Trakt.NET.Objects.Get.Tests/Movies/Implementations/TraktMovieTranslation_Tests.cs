namespace TraktNet.Objects.Get.Tests.Movies.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.Implementations")]
    public class TraktMovieTranslation_Tests
    {
        [Fact]
        public void Test_TraktMovieTranslation_Default_Constructor()
        {
            var movieTranslation = new TraktMovieTranslation();

            movieTranslation.Title.Should().BeNull();
            movieTranslation.Overview.Should().BeNull();
            movieTranslation.Tagline.Should().BeNull();
            movieTranslation.LanguageCode.Should().BeNull();
            movieTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslation_From_Json()
        {
            var jsonReader = new MovieTranslationObjectJsonReader();
            var movieTranslation = await jsonReader.ReadObjectAsync(JSON) as TraktMovieTranslation;

            movieTranslation.Should().NotBeNull();
            movieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            movieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            movieTranslation.Tagline.Should().Be("The Force Lives On...");
            movieTranslation.LanguageCode.Should().Be("en");
            movieTranslation.CountryCode.Should().Be("us");
        }

        private const string JSON =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas,..."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";
    }
}
