namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();
            IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktSearchResults.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSearchResults.Should().BeNull();
            }
        }
    }
}
