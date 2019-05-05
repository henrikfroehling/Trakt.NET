namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonWriter")]
    public partial class UserCustomListsReorderPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_Object_Only_Updated_Property()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                Updated = 6
            };

            var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserCustomListsReorderPostResponse);
            json.Should().Be(@"{""updated"":6}");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_Object_Only_SkippedIds_Property()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                SkippedIds = new List<uint> { 2 }
            };

            var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserCustomListsReorderPostResponse);
            json.Should().Be(@"{""skipped_ids"":[2]}");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktUserCustomListsReorderPostResponse traktUserCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 }
            };

            var traktJsonWriter = new UserCustomListsReorderPostResponseObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserCustomListsReorderPostResponse);
            json.Should().Be(@"{""updated"":6,""skipped_ids"":[2]}");
        }
    }
}
