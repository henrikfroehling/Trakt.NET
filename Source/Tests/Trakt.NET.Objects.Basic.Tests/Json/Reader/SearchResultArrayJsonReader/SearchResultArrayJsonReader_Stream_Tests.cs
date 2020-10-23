namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public void Test_SearchResultArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            Func<Task<IEnumerable<ITraktSearchResult>>> traktSearchResults = () => jsonReader.ReadArrayAsync(default(Stream));
            traktSearchResults.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);
                traktSearchResults.Should().BeNull();
            }
        }
    }
}
