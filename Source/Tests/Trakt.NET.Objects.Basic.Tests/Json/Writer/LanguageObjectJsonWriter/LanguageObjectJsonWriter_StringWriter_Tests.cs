namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class LanguageObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new LanguageObjectJsonWriter();
            ITraktLanguage traktLanguage = new TraktLanguage();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktLanguage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_StringWriter_Only_Name_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktLanguage);
                json.Should().Be(@"{""name"":""English""}");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_StringWriter_Only_Code_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Code = "en"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktLanguage);
                json.Should().Be(@"{""code"":""en""}");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English",
                Code = "en"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktLanguage);
                json.Should().Be(@"{""name"":""English"",""code"":""en""}");
            }
        }
    }
}
