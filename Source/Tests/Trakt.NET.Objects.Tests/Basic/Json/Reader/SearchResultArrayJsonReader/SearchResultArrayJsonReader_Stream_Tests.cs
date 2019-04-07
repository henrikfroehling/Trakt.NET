namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new SearchResultArrayJsonReader();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(default(Stream));
            traktSearchResults.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);
                traktSearchResults.Should().BeNull();
            }
        }
    }
}
