namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class TraktShowTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().BeNull();
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().BeNull();
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().BeNull();
                traktShowTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().BeNull();
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().BeNull();
                traktShowTranslation.Overview.Should().BeNull();
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().BeNull();
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().BeNull();
                traktShowTranslation.LanguageCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().Be("Game of Thrones");
                traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
                traktShowTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowTranslation.Should().NotBeNull();
                traktShowTranslation.Title.Should().BeNull();
                traktShowTranslation.Overview.Should().BeNull();
                traktShowTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktShowTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktShowTranslationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktShowTranslation.Should().BeNull();
            }
        }
    }
}
