namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class LanguageArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            IEnumerable<ITraktLanguage> traktLanguages = new List<TraktLanguage>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktLanguages);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<TraktLanguage>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktLanguages);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktLanguages);
                stringWriter.ToString().Should().Be(@"[{""name"":""English"",""code"":""en""}]");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktLanguages);
                stringWriter.ToString().Should().Be(@"[{""name"":""English"",""code"":""en""}," +
                                                    @"{""name"":""Italian"",""code"":""it""}," +
                                                    @"{""name"":""Polish"",""code"":""pl""}]");
            }
        }
    }
}
