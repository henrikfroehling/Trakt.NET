namespace Trakt.NET.Objects.Tests.Post.Users.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Users.Responses;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonWriter")]
    public partial class UserCustomListsReorderPostResponseArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<TraktUserCustomListsReorderPostResponse>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktUserCustomListsReorderPostResponses);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<TraktUserCustomListsReorderPostResponse>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktUserCustomListsReorderPostResponses);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<ITraktUserCustomListsReorderPostResponse>
            {
                new TraktUserCustomListsReorderPostResponse
                {
                    Updated = 6,
                    SkippedIds = new List<uint> { 2 }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktUserCustomListsReorderPostResponses);
                json.Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_StringWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktUserCustomListsReorderPostResponses);
                json.Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}," +
                                 @"{""updated"":6,""skipped_ids"":[2]}]");
            }
        }
    }
}
