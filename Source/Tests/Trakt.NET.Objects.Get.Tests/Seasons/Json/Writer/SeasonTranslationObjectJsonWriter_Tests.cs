namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktSeasonTranslation));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Only_Title_Property()
        {
            ITraktSeasonTranslation traktSeasonTranslation = new TraktSeasonTranslation
            {
                Title = "title"
            };

            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonTranslation);
            json.Should().Be(@"{""title"":""title""}");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Only_Overview_Property()
        {
            ITraktSeasonTranslation traktSeasonTranslation = new TraktSeasonTranslation
            {
                Overview = "overview"
            };

            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonTranslation);
            json.Should().Be(@"{""overview"":""overview""}");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Only_LanguageCode_Property()
        {
            ITraktSeasonTranslation traktSeasonTranslation = new TraktSeasonTranslation
            {
                LanguageCode = "en"
            };

            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonTranslation);
            json.Should().Be(@"{""language"":""en""}");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Only_CountryCode_Property()
        {
            ITraktSeasonTranslation traktSeasonTranslation = new TraktSeasonTranslation
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonTranslation);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSeasonTranslation traktSeasonTranslation = new TraktSeasonTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "en",
                CountryCode = "us"
            };

            var traktJsonWriter = new SeasonTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonTranslation);
            json.Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""en"",""country"":""us""}");
        }
    }
}
