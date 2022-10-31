namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.JsonWriter")]
    public partial class ListItemsReorderPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Only_Updated_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6
            };

            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPostResponse);
            json.Should().Be(@"{""updated"":6}");
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Only_SkippedIds_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                SkippedIds = new List<uint> { 2 }
            };

            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPostResponse);
            json.Should().Be(@"{""skipped_ids"":[2]}");
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 }
            };

            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPostResponse);
            json.Should().Be(@"{""updated"":6,""skipped_ids"":[2]}");
        }
    }
}
