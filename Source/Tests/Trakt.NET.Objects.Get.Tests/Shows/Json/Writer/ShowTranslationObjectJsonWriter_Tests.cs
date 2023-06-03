namespace TraktNet.Objects.Get.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonWriter")]
    public partial class ShowTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktShowTranslation));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Only_Title_Property()
        {
            ITraktShowTranslation traktShowTranslation = new TraktShowTranslation
            {
                Title = "title"
            };

            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowTranslation);
            json.Should().Be(@"{""title"":""title""}");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Only_Overview_Property()
        {
            ITraktShowTranslation traktShowTranslation = new TraktShowTranslation
            {
                Overview = "overview"
            };

            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowTranslation);
            json.Should().Be(@"{""overview"":""overview""}");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Only_LanguageCode_Property()
        {
            ITraktShowTranslation traktShowTranslation = new TraktShowTranslation
            {
                LanguageCode = "en"
            };

            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowTranslation);
            json.Should().Be(@"{""language"":""en""}");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Only_CountryCode_Property()
        {
            ITraktShowTranslation traktShowTranslation = new TraktShowTranslation
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowTranslation);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktShowTranslation traktShowTranslation = new TraktShowTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "en",
                CountryCode = "us"
            };

            var traktJsonWriter = new ShowTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowTranslation);
            json.Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""en"",""country"":""us""}");
        }
    }
}
