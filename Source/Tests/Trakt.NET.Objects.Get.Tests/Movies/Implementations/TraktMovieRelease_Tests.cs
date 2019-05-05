namespace TraktNet.Objects.Get.Tests.Movies.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktMovieRelease_Tests
    {
        [Fact]
        public void Test_TraktMovieRelease_Default_Constructor()
        {
            var movieRelease = new TraktMovieRelease();

            movieRelease.CountryCode.Should().BeNullOrEmpty();
            movieRelease.Certification.Should().BeNullOrEmpty();
            movieRelease.ReleaseDate.Should().NotHaveValue();
            movieRelease.ReleaseType.Should().BeNull();
            movieRelease.Note.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMovieRelease_From_Json()
        {
            var jsonReader = new MovieReleaseObjectJsonReader();
            var movieRelease = await jsonReader.ReadObjectAsync(JSON) as TraktMovieRelease;

            movieRelease.Should().NotBeNull();
            movieRelease.CountryCode.Should().Be("us");
            movieRelease.Certification.Should().Be("PG-13");
            movieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            movieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            movieRelease.Note.Should().Be("Los Angeles, California");
        }

        private const string JSON =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";
    }
}
