﻿namespace TraktNet.Objects.Tests.Get.History.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
