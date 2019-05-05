namespace TraktNet.Objects.Tests.Post.Users.Responses.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.Implementations")]
    public class TraktUserCustomListsReorderPostResponse_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListsReorderPostResponse_Default_Constructor()
        {
            var userCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse();

            userCustomListsReorderPostResponse.Updated.Should().BeNull();
            userCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCustomListsReorderPostResponse_From_Json()
        {
            var jsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var userCustomListsReorderPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktUserCustomListsReorderPostResponse;

            userCustomListsReorderPostResponse.Should().NotBeNull();

            userCustomListsReorderPostResponse.Updated.Should().Be(6);
            userCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            userCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        private const string JSON =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ]
              }";
    }
}
