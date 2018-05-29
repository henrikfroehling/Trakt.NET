namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeTranslationArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeTranslation>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktEpisodeTranslation>));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktEpisodeTranslation> traktEpisodeTranslations = new List<TraktEpisodeTranslation>();

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeTranslation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeTranslations);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktEpisodeTranslation> traktEpisodeTranslations = new List<ITraktEpisodeTranslation>
            {
                new TraktEpisodeTranslation
                {
                    Title = "title 1",
                    Overview = "overview 1",
                    LanguageCode = "language code 1"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeTranslation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeTranslations);
            json.Should().Be(@"[{""title"":""title 1"",""overview"":""overview 1"",""language"":""language code 1""}]");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktEpisodeTranslation> traktEpisodeTranslations = new List<ITraktEpisodeTranslation>
            {
                new TraktEpisodeTranslation
                {
                    Title = "title 1",
                    Overview = "overview 1",
                    LanguageCode = "language code 1"
                },
                new TraktEpisodeTranslation
                {
                    Title = "title 2",
                    Overview = "overview 2",
                    LanguageCode = "language code 2"
                },
                new TraktEpisodeTranslation
                {
                    Title = "title 3",
                    Overview = "overview 3",
                    LanguageCode = "language code 3"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeTranslation>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeTranslations);
            json.Should().Be(@"[{""title"":""title 1"",""overview"":""overview 1"",""language"":""language code 1""}," +
                             @"{""title"":""title 2"",""overview"":""overview 2"",""language"":""language code 2""}," +
                             @"{""title"":""title 3"",""overview"":""overview 3"",""language"":""language code 3""}]");
        }
    }
}
