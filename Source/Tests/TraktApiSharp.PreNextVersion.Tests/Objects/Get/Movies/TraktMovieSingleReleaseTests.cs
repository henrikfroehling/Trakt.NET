namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieSingleReleaseTests
    {
        [TestMethod]
        public void TestTraktMovieSingleReleaseDefaultConstructor()
        {
            var release = new TraktMovieRelease();

            release.CountryCode.Should().BeNullOrEmpty();
            release.Certification.Should().BeNullOrEmpty();
            release.ReleaseDate.Should().NotHaveValue();
            release.ReleaseType.Should().BeNull();
            release.Note.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktMovieSingleReleaseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleRelease.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var release = JsonConvert.DeserializeObject<TraktMovieRelease>(jsonFile);

            release.Should().NotBeNull();
            release.CountryCode.Should().Be("us");
            release.Certification.Should().Be("PG-13");
            release.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            release.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            release.Note.Should().Be("Los Angeles, California");
        }
    }
}
