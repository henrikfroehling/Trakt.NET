namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SearchResultObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SearchResultObjectJsonReader();
            Func<Task<ITraktSearchResult>> traktSearchResultItem = () => jsonReader.ReadObjectAsync(default(string));
            traktSearchResultItem.Should().Throw<ArgumentNullException>();
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
