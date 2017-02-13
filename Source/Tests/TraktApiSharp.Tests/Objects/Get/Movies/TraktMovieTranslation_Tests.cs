namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktMovieTranslation_Tests
    {
        [Fact]
        public void Test_TraktMovieTranslation_Default_Constructor()
        {
            var movieTranslation = new TraktMovieTranslation();

            movieTranslation.Title.Should().BeNullOrEmpty();
            movieTranslation.Overview.Should().BeNullOrEmpty();
            movieTranslation.Tagline.Should().BeNullOrEmpty();
            movieTranslation.LanguageCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktMovieTranslation_From_Json()
        {
            var movieTranslation = JsonConvert.DeserializeObject<TraktMovieTranslation>(JSON);

            movieTranslation.Should().NotBeNull();
            movieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            movieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            movieTranslation.Tagline.Should().Be("The Force Lives On...");
            movieTranslation.LanguageCode.Should().Be("en");
        }

        private const string JSON =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";
    }
}
