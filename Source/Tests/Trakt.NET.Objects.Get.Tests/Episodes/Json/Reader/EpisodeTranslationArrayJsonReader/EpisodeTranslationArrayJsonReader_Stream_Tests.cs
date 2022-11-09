namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeTranslations.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();
            Func<Task<IEnumerable<ITraktEpisodeTranslation>>> traktEpisodeTranslations = () => traktJsonReader.ReadArrayAsync(default(Stream));
            await traktEpisodeTranslations.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeTranslation>();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeTranslations = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeTranslations.Should().BeNull();
            }
        }
    }
}
