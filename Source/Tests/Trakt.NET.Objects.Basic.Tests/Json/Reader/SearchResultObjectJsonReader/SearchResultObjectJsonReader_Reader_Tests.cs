namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();
            Func<Task<ITraktSearchResult>> traktSearchResultItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSearchResultItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSearchResultItem.Should().BeNull();
            }
        }
    }
}
