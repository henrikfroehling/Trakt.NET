namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktEpisodeTranslation);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_StringWriter_Only_Title_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeTranslation);
                json.Should().Be(@"{""title"":""title""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_StringWriter_Only_Overview_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Overview = "overview"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeTranslation);
                json.Should().Be(@"{""overview"":""overview""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_StringWriter_Only_LanguageCode_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                LanguageCode = "language code"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeTranslation);
                json.Should().Be(@"{""language"":""language code""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "language code"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeTranslation);
                json.Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""language code""}");
            }
        }
    }
}
