namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktEpisodeTranslation);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_JsonWriter_Only_Title_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeTranslation);
                stringWriter.ToString().Should().Be(@"{""title"":""title""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_JsonWriter_Only_Overview_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Overview = "overview"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeTranslation);
                stringWriter.ToString().Should().Be(@"{""overview"":""overview""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_JsonWriter_Only_LanguageCode_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                LanguageCode = "language code"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeTranslation);
                stringWriter.ToString().Should().Be(@"{""language"":""language code""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "language code"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeTranslation);
                stringWriter.ToString().Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""language code""}");
            }
        }
    }
}
