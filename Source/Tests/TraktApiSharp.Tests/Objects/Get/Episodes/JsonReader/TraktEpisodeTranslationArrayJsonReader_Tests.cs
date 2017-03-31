namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Episodes")]
    public class TraktEpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktEpisodeTranslationArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<TraktEpisodeTranslation>));
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_EMPTY_ARRAY);
            traktEpisodeTranslations.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_COMPLETE);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_1);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_2);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_3);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_4);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().BeNull();
            translations[0].LanguageCode.Should().BeNull();

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_5);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().BeNull();
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().BeNull();

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_INCOMPLETE_6);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().BeNull();
            translations[2].Overview.Should().BeNull();
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_NOT_VALID_1);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_NOT_VALID_2);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_NOT_VALID_3);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(JSON_NOT_VALID_4);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(default(string));
            traktEpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(string.Empty);
            traktEpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().BeNull();
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().BeNull();
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().BeNull();
                translations[0].LanguageCode.Should().BeNull();

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().BeNull();
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().BeNull();

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().BeNull();
                translations[2].Overview.Should().BeNull();
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().BeNull();
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().BeNull();
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().Be("Translation Language 3");
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().Be("Translation 1");
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().Be("Translation Overview 2");
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var translations = traktEpisodeTranslations.ToArray();

                translations[0].Title.Should().BeNull();
                translations[0].Overview.Should().Be("Translation Overview 1");
                translations[0].LanguageCode.Should().Be("Translation Language 1");

                translations[1].Title.Should().Be("Translation 2");
                translations[1].Overview.Should().BeNull();
                translations[1].LanguageCode.Should().Be("Translation Language 2");

                translations[2].Title.Should().Be("Translation 3");
                translations[2].Overview.Should().Be("Translation Overview 3");
                translations[2].LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var jsonReader = new TraktEpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = jsonReader.ReadArray(default(JsonTextReader));
            traktEpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktEpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeTranslations.Should().BeNull();
            }
        }

        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3""
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""title"": ""Translation 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""overview"": ""Translation Overview 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""ti"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""ov"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""la"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""ti"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""ov"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""la"": ""Translation Language 3""
                }
              ]";
    }
}
