namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<TraktUserCustomListsReorderPostResponse>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktUserCustomListsReorderPostResponses);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktUserCustomListsReorderPostResponse> traktUserCustomListsReorderPostResponses = new List<TraktUserCustomListsReorderPostResponse>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPostResponses);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPostResponses);
                stringWriter.ToString().Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPostResponse>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPostResponses);
                stringWriter.ToString().Should().Be(@"[{""updated"":6,""skipped_ids"":[2]}," +
                                                    @"{""updated"":6,""skipped_ids"":[2]}]");
            }
        }
    }
}
