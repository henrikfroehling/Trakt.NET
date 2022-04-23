﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktSearchResult>();
            Func<Task<IEnumerable<ITraktSearchResult>>> traktSearchResults = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktSearchResults.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSearchResults.Should().BeNull();
            }
        }
    }
}
