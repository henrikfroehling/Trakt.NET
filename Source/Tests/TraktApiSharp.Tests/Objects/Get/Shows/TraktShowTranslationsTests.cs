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
    public class TraktShowTranslationsTests
    {
        [TestMethod]
        public void TestTraktShowTranslationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var translations = JsonConvert.DeserializeObject<IEnumerable<TraktShowTranslation>>(jsonFile);

            translations.Should().NotBeNull();
            translations.Should().HaveCount(4);

            var translationsArray = translations.ToArray();

            translationsArray[0].Title.Should().Be("Game of Thrones");
            translationsArray[0].Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and icy horrors beyond.\n\n");
            translationsArray[0].LanguageCode.Should().Be("en");
            translationsArray[0].Language.Should().NotBeNull();

            translationsArray[1].Title.Should().Be("Le Trône de fer");
            translationsArray[1].Overview.Should().Be("Il y a très longtemps, à une époque oubliée, une force a détruit l'équilibre des saisons. Dans un pays où l'été peut durer plusieurs années et l'hiver toute une vie, des forces sinistres et surnaturelles se pressent aux portes du Royaume des Sept Couronnes. La confrérie de la Garde de Nuit, protégeant le Royaume de toute créature pouvant provenir d'au-delà du Mur protecteur, n'a plus les ressources nécessaires pour assurer la sécurité de tous. Après un été de dix années, un hiver rigoureux s'abat sur le Royaume avec la promesse d'un avenir des plus sombres. Pendant ce temps, complots et rivalités se jouent sur le continent pour s'emparer du Trône de fer, le symbole du pouvoir absolu.");
            translationsArray[1].LanguageCode.Should().Be("fr");
            translationsArray[1].Language.Should().NotBeNull();

            translationsArray[2].Title.Should().Be("Il Trono di Spade");
            translationsArray[2].Overview.Should().Be("Il Trono di Spade (Game of Thrones) è una serie televisiva statunitense di genere fantasy creata da David Benioff e D.B. Weiss, che ha debuttato il 17 aprile 2011 sul canale via cavo HBO. È nata come trasposizione televisiva del ciclo di romanzi Cronache del ghiaccio e del fuoco (A Song of Ice and Fire) di George R. R. Martin.\n\nLa serie racconta le avventure di molti personaggi che vivono in un grande mondo immaginario costituito principalmente da due continenti. Il centro più grande e civilizzato del continente occidentale è la città capitale Approdo del Re, dove risiede il Trono di Spade. La lotta per la conquista del trono porta le più grandi famiglie del continente a scontrarsi o allearsi tra loro in un contorto gioco del potere. Ma oltre agli uomini, emergono anche altre forze oscure e magiche.");
            translationsArray[2].LanguageCode.Should().Be("it");
            translationsArray[2].Language.Should().NotBeNull();

            translationsArray[3].Title.Should().Be("Game of Thrones");
            translationsArray[3].Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            translationsArray[3].LanguageCode.Should().Be("de");
            translationsArray[3].Language.Should().NotBeNull();
        }
    }
}
