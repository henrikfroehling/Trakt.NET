﻿namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();
            Func<Task<IList<ITraktHistoryItem>>> traktHistoryItems = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktHistoryItems.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktHistoryItem>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktHistoryItems.Should().BeNull();
            }
        }
    }
}
