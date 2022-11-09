namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.JsonWriter")]
    public partial class ListItemsReorderPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), listItemsReorderPostResponse);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_StringWriter_Only_Updated_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, listItemsReorderPostResponse);
                json.Should().Be(@"{""updated"":6}");
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_StringWriter_Only_SkippedIds_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, listItemsReorderPostResponse);
                json.Should().Be(@"{""skipped_ids"":[2]}");
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, listItemsReorderPostResponse);
                json.Should().Be(@"{""updated"":6,""skipped_ids"":[2]}");
            }
        }
    }
}
