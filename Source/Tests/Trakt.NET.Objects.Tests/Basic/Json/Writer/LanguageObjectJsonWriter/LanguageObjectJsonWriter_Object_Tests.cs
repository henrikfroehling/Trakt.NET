namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class LanguageObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_LanguageObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new LanguageObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_Object_Only_Name_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English"
            };

            var traktJsonWriter = new LanguageObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktLanguage);
            json.Should().Be(@"{""name"":""English""}");
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_Object_Only_Code_Property()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Code = "en"
            };

            var traktJsonWriter = new LanguageObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktLanguage);
            json.Should().Be(@"{""code"":""en""}");
        }

        [Fact]
        public async Task Test_LanguageObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktLanguage traktLanguage = new TraktLanguage
            {
                Name = "English",
                Code = "en"
            };

            var traktJsonWriter = new LanguageObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktLanguage);
            json.Should().Be(@"{""name"":""English"",""code"":""en""}");
        }
    }
}
