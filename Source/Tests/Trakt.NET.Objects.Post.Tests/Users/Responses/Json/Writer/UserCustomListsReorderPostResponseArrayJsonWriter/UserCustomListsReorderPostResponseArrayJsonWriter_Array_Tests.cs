namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Users.Responses;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonWriter")]
    public partial class UserCustomListsReorderPostResponseArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<TraktUserCustomListsReorderPostResponse>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPostResponses);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<ITraktUserCustomListsReorderPostResponse>
            {
                new TraktUserCustomListsReorderPostResponse
                {
                    Updated = 6,
                    SkippedIds = new List<uint> { 2 }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPostResponses);
            json.Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}]");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<ITraktUserCustomListsReorderPostResponse>
            {
                new TraktUserCustomListsReorderPostResponse
                {
                    Updated = 6,
                    SkippedIds = new List<uint> { 2 }
                },
                new TraktUserCustomListsReorderPostResponse
                {
                    Updated = 6,
                    SkippedIds = new List<uint> { 2 }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPostResponses);
            json.Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}," +
                             @"{""updated"":6,""skipped_ids"":[2]}]");
        }
    }
}
