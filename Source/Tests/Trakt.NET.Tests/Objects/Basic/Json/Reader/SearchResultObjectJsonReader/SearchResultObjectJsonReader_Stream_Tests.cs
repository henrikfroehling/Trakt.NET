namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktSearchResultItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);
                traktSearchResultItem.Should().BeNull();
            }
        }
    }
}
