namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Movies
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Movies;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class TraktMovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMovieTranslationObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktMovieTranslation>));
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_COMPLETE);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(default(string));
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(string.Empty);
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktMovieTranslationObjectJsonReader();

            var traktMovieTranslation = jsonReader.ReadObject(default(JsonTextReader));
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktMovieTranslationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieTranslation = traktJsonReader.ReadObject(jsonReader);
                traktMovieTranslation.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On...""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tagline"": ""The Force Lives On...""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tl"": ""The Force Lives On..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Star Wars: Episode VII - The Force Awakens"",
                ""overview"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tagline"": ""The Force Lives On..."",
                ""la"": ""en""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ti"": ""Star Wars: Episode VII - The Force Awakens"",
                ""ov"": ""A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi."",
                ""tl"": ""The Force Lives On..."",
                ""la"": ""en""
              }";
    }
}
