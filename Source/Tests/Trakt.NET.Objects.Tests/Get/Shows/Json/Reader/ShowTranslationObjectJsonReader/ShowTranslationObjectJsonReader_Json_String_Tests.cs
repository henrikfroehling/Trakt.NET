namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            traktShowTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(default(string));
            traktShowTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ShowTranslationObjectJsonReader();

            var traktShowTranslation = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowTranslation.Should().BeNull();
        }
    }
}
