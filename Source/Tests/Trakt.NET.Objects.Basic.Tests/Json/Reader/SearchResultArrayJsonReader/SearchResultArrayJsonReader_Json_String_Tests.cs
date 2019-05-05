namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new SearchResultArrayJsonReader();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(default(string));
            traktSearchResults.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new SearchResultArrayJsonReader();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(string.Empty);
            traktSearchResults.Should().BeNull();
        }
    }
}
