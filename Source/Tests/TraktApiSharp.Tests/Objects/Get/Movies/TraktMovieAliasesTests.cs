namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieAliasesTests
    {
        [TestMethod]
        public void TestTraktMovieAliasesReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieAliases.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var aliases = JsonConvert.DeserializeObject<IEnumerable<TraktMovieAlias>>(jsonFile);

            aliases.Should().NotBeNull();
            aliases.Should().HaveCount(4);

            var aliasesArray = aliases.ToArray();

            aliasesArray[0].Title.Should().Be("Star Wars 7");
            aliasesArray[0].CountryCode.Should().Be("us");
            aliasesArray[0].Country.Should().NotBeNull();

            aliasesArray[1].Title.Should().Be("Star Wars: O Despertar da Força");
            aliasesArray[1].CountryCode.Should().Be("br");
            aliasesArray[1].Country.Should().NotBeNull();

            aliasesArray[2].Title.Should().Be("Star Wars El despertar de la Fuerza");
            aliasesArray[2].CountryCode.Should().Be("es");
            aliasesArray[2].Country.Should().NotBeNull();

            aliasesArray[3].Title.Should().Be("La guerra de las galaxias. Episodio 7. El despertar de la Fuerza.");
            aliasesArray[3].CountryCode.Should().Be("es");
            aliasesArray[3].Country.Should().NotBeNull();
        }
    }
}
