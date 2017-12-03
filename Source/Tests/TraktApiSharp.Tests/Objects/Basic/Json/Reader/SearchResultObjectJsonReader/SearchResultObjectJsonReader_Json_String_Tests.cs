namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(default(string));
            traktSearchResultItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktSearchResultItem.Should().BeNull();
        }
    }
}
