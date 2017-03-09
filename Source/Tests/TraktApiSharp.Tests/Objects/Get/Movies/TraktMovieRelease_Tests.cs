namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.JsonReader.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
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
        public void Test_TraktMovieRelease_From_Json()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();
            var movieRelease = jsonReader.ReadObject(JSON);

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
