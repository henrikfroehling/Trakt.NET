namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowTranslation_Tests
    {
        [Fact]
        public void Test_TraktShowTranslation_Inherits_TraktTranslation()
        {
            typeof(TraktShowTranslation).IsSubclassOf(typeof(TraktTranslation)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowTranslation_Implements_ITraktShowTranslation_Interface()
        {
            typeof(TraktShowTranslation).GetInterfaces().Should().Contain(typeof(ITraktShowTranslation));
        }

        [Fact]
        public void Test_TraktShowTranslation_Default_Constructor()
        {
            var showTranslation = new TraktShowTranslation();

            showTranslation.Title.Should().BeNullOrEmpty();
            showTranslation.Overview.Should().BeNullOrEmpty();
            showTranslation.LanguageCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktShowTranslation_From_Json()
        {
            var jsonReader = new TraktShowTranslationObjectJsonReader();
            var showTranslation = jsonReader.ReadObject(JSON);

            showTranslation.Should().NotBeNull();
            showTranslation.Title.Should().Be("Game of Thrones");
            showTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            showTranslation.LanguageCode.Should().Be("de");
        }

        private const string JSON =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion."",
                ""language"": ""de""
              }";
    }
}
