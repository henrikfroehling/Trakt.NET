namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();
            Func<Task<ITraktEpisodeTranslation>> traktEpisodeTranslation = () => traktJsonReader.ReadObjectAsync(default(Stream));
            traktEpisodeTranslation.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(stream);
                traktEpisodeTranslation.Should().BeNull();
            }
        }
    }
}
