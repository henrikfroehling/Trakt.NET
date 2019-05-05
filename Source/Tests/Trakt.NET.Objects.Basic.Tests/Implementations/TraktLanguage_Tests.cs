namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktLanguage_Tests
    {
        [Fact]
        public void Test_TraktLanguage_Default_Constructor()
        {
            var traktLanguage = new TraktLanguage();

            traktLanguage.Name.Should().BeNull();
            traktLanguage.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktLanguage_From_Json()
        {
            var jsonReader = new LanguageObjectJsonReader();
            var traktLanguage = await jsonReader.ReadObjectAsync(JSON) as TraktLanguage;

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().Be("English");
            traktLanguage.Code.Should().Be("en");
        }

        private const string JSON =
            @"{
                ""name"": ""English"",
                ""code"": ""en""
              }";
    }
}
