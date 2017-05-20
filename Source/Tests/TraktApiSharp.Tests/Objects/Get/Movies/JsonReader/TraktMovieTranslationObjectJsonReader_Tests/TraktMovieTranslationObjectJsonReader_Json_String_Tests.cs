namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TraktMovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(default(string));
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovieTranslation.Should().BeNull();
        }
    }
}
