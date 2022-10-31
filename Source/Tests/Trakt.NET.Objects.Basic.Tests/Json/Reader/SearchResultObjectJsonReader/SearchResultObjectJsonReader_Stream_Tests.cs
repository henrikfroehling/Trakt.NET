namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SearchResultObjectJsonReader();
            Func<Task<ITraktSearchResult>> traktSearchResultItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktSearchResultItem.Should().ThrowAsync<ArgumentNullException>();
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
