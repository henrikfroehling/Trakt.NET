﻿namespace TraktNet.Objects.Tests.Get.Episodes.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeTranslations.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktEpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeTranslationArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeTranslations.Should().BeNull();
            }
        }
    }
}
