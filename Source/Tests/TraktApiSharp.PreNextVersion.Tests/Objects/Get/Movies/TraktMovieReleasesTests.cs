namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieReleasesTests
    {
        [TestMethod]
        public void TestTraktMovieReleasesReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var releases = JsonConvert.DeserializeObject<IEnumerable<TraktMovieRelease>>(jsonFile);

            releases.Should().NotBeNull();
            releases.Should().HaveCount(3);

            var releasesArray = releases.ToArray();

            releasesArray[0].CountryCode.Should().Be("us");
            releasesArray[0].Certification.Should().Be("PG-13");
            releasesArray[0].ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            releasesArray[0].ReleaseType.Should().Be(TraktReleaseType.Premiere);
            releasesArray[0].Note.Should().Be("Los Angeles, California");

            releasesArray[1].CountryCode.Should().Be("ae");
            releasesArray[1].Certification.Should().BeEmpty();
            releasesArray[1].ReleaseDate.Should().Be(DateTime.Parse("2015-12-15"));
            releasesArray[1].ReleaseType.Should().Be(TraktReleaseType.Theatrical);
            releasesArray[1].Note.Should().BeNullOrEmpty();

            releasesArray[2].CountryCode.Should().Be("fr");
            releasesArray[2].Certification.Should().BeEmpty();
            releasesArray[2].ReleaseDate.Should().Be(DateTime.Parse("2015-12-16"));
            releasesArray[2].ReleaseType.Should().Be(TraktReleaseType.Theatrical);
            releasesArray[2].Note.Should().BeNullOrEmpty();
        }
    }
}
