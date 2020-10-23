namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class LanguageArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_LanguageArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            IEnumerable<ITraktLanguage> traktLanguages = new List<TraktLanguage>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktLanguages);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<TraktLanguage>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktLanguages);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<ITraktLanguage>
            {
                new TraktLanguage
                {
                    Name = "English",
                    Code = "en"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktLanguages);
                json.Should().Be(@"[{""name"":""English"",""code"":""en""}]");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<ITraktLanguage>
            {
                new TraktLanguage
                {
                    Name = "English",
                    Code = "en"
                },
                new TraktLanguage
                {
                    Name = "Italian",
                    Code = "it"
                },
                new TraktLanguage
                {
                    Name = "Polish",
                    Code = "pl"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktLanguages);
                json.Should().Be(@"[{""name"":""English"",""code"":""en""}," +
                                 @"{""name"":""Italian"",""code"":""it""}," +
                                 @"{""name"":""Polish"",""code"":""pl""}]");
            }
        }
    }
}
