namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovieTranslation.Should().BeNull();
            }
        }
    }
}
