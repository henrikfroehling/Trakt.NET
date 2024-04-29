namespace TraktNet.Objects.Post.Tests.Basic.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.Implementations")]
    public class TraktListItemsReorderPostResponse_Tests
    {
        [Fact]
        public void Test_TraktListItemsReorderPostResponse_Default_Constructor()
        {
            var listItemsReorderPostResponse = new TraktListItemsReorderPostResponse();

            listItemsReorderPostResponse.Updated.Should().BeNull();
            listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            listItemsReorderPostResponse.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemsReorderPostResponse_From_Json()
        {
            var jsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktListItemsReorderPostResponse;

            listItemsReorderPostResponse.Should().NotBeNull();

            listItemsReorderPostResponse.Updated.Should().Be(6);
            listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });

            listItemsReorderPostResponse.List.Should().NotBeNull();
            listItemsReorderPostResponse.List.UpdatedAt.Should().Be(DateTime.Parse("2022-04-27T21:40:41.000Z").ToUniversalTime());
            listItemsReorderPostResponse.List.ItemCount.Should().Be(5);
        }

        private const string JSON =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ],
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";
    }
}
