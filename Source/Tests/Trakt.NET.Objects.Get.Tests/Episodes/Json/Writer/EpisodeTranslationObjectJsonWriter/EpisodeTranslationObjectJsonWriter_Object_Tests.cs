﻿namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktEpisodeTranslation));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_Object_Only_Title_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title"
            };

            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeTranslation);
            json.Should().Be(@"{""title"":""title""}");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_Object_Only_Overview_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Overview = "overview"
            };

            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeTranslation);
            json.Should().Be(@"{""overview"":""overview""}");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_Object_Only_LanguageCode_Property()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                LanguageCode = "language code"
            };

            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeTranslation);
            json.Should().Be(@"{""language"":""language code""}");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "language code"
            };

            var traktJsonWriter = new EpisodeTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeTranslation);
            json.Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""language code""}");
        }
    }
}
