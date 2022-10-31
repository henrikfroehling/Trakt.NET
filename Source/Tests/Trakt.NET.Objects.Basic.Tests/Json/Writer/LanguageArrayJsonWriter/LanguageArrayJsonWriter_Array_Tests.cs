namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class LanguageArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<TraktLanguage>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktLanguages);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktLanguage> traktLanguages = new List<ITraktLanguage>
            {
                new TraktLanguage
                {
                    Name = "English",
                    Code = "en"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktLanguages);
            json.Should().Be(@"[{""name"":""English"",""code"":""en""}]");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktLanguage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktLanguages);
            json.Should().Be(@"[{""name"":""English"",""code"":""en""}," +
                             @"{""name"":""Italian"",""code"":""it""}," +
                             @"{""name"":""Polish"",""code"":""pl""}]");
        }
    }
}
