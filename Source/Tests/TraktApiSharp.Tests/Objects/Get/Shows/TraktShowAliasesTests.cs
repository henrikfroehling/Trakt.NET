namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowAliasesTests
    {
        [TestMethod]
        public void TestTraktShowAliasesReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowAliases.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var aliases = JsonConvert.DeserializeObject<IEnumerable<TraktShowAlias>>(jsonFile);

            aliases.Should().NotBeNull();
            aliases.Should().HaveCount(8);

            var aliasesArray = aliases.ToArray();

            aliasesArray[0].Title.Should().Be("冰與火之歌：權力遊戲");
            aliasesArray[0].CountryCode.Should().Be("tw");
            aliasesArray[0].Country.Should().NotBeNull();

            aliasesArray[1].Title.Should().Be("A Guerra dos Tronos");
            aliasesArray[1].CountryCode.Should().Be("pt");
            aliasesArray[1].Country.Should().NotBeNull();

            aliasesArray[2].Title.Should().Be("Game of Thrones");
            aliasesArray[2].CountryCode.Should().Be("ru");
            aliasesArray[2].Country.Should().NotBeNull();

            aliasesArray[3].Title.Should().Be("بازی تاج و تخت");
            aliasesArray[3].CountryCode.Should().Be("aq");
            aliasesArray[3].Country.Should().NotBeNull();

            aliasesArray[4].Title.Should().Be("Igra prijestolja");
            aliasesArray[4].CountryCode.Should().Be("hr");
            aliasesArray[4].Country.Should().NotBeNull();

            aliasesArray[5].Title.Should().Be("Το Παιχνίδι του θρόνου");
            aliasesArray[5].CountryCode.Should().Be("gr");
            aliasesArray[5].Country.Should().NotBeNull();

            aliasesArray[6].Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            aliasesArray[6].CountryCode.Should().Be("de");
            aliasesArray[6].Country.Should().NotBeNull();

            aliasesArray[7].Title.Should().Be("Παιχνίδι Του Στέμματος");
            aliasesArray[7].CountryCode.Should().Be("gr");
            aliasesArray[7].Country.Should().NotBeNull();
        }
    }
}
