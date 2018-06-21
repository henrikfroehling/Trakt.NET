namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSearchResultItem.Should().BeNull();
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
