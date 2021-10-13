namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class LanguageObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new LanguageObjectJsonWriter();
            ITraktLanguage traktLanguage = new TraktLanguage();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktLanguage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_JsonWriter_Only_Name_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktLanguage);
                stringWriter.ToString().Should().Be(@"{""name"":""English""}");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_JsonWriter_Only_Code_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Code = "en"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktLanguage);
                stringWriter.ToString().Should().Be(@"{""code"":""en""}");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English",
                Code = "en"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new LanguageObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktLanguage);
                stringWriter.ToString().Should().Be(@"{""name"":""English"",""code"":""en""}");
            }
        }
    }
}
