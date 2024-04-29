namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Writer;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.JsonWriter")]
    public partial class ListItemsReorderPostResponseObjectJsonWriter_Tests
    {
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

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
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Only_List_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                List = new TraktPostResponseListData
                {
                    UpdatedAt = UPDATED_AT,
                    ItemCount = 5
                }
            };

            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPostResponse);
            json.Should().Be($"{{\"list\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\",\"item_count\":5}}}}");
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 },
                List = new TraktPostResponseListData
                {
                    UpdatedAt = UPDATED_AT,
                    ItemCount = 5
                }
            };

            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPostResponse);
            json.Should().Be(@"{""updated"":6,""skipped_ids"":[2]," +
                             $"\"list\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\",\"item_count\":5}}}}");
        }
    }
}
