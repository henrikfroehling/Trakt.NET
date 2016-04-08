namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieSingleAliasTests
    {
        [TestMethod]
        public void TestTraktMovieSingleAliasDefaultConstructor()
        {
            var alias = new TraktMovieAlias();

            alias.Title.Should().BeNullOrEmpty();
            alias.CountryCode.Should().BeNullOrEmpty();
            alias.Country.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMovieSingleAliasReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Movies\MovieSingleAlias.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var alias = JsonConvert.DeserializeObject<TraktMovieAlias>(jsonFile);

            alias.Should().NotBeNull();
            alias.Title.Should().Be("La guerra de las galaxias. Episodio 7. El despertar de la Fuerza.");
            alias.CountryCode.Should().Be("es");
            alias.Country.Should().NotBeNull();
        }
    }
}
