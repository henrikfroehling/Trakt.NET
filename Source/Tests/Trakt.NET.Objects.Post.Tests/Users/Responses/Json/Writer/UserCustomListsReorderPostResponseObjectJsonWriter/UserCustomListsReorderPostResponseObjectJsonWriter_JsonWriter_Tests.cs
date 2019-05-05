namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonWriter")]
    public partial class UserCustomListsReorderPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktUserCustomListsReorderPostResponse);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Only_Updated_Property()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                Updated = 6
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserCustomListsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""updated"":6}");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Only_SkippedIds_Property()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserCustomListsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""skipped_ids"":[2]}");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserCustomListsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""updated"":6,""skipped_ids"":[2]}");
            }
        }
    }
}
