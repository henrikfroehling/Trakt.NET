namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Shows;
    using Utils;

    [TestClass]
    public class TraktShowSingleTranslationTests
    {
        [TestMethod]
        public void TestTraktShowSingleTranslationDefaultConstructor()
        {
            var translation = new TraktShowTranslation();

            translation.Title.Should().BeNullOrEmpty();
            translation.Overview.Should().BeNullOrEmpty();
            translation.LanguageCode.Should().BeNullOrEmpty();
            translation.Language.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowSingleTranslationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\ShowSingleTranslation.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translation = JsonConvert.DeserializeObject<TraktShowTranslation>(jsonFile);

            translation.Should().NotBeNull();
            translation.Title.Should().Be("Game of Thrones");
            translation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            translation.LanguageCode.Should().Be("de");
            translation.Language.Should().NotBeNull();
        }
    }
}
