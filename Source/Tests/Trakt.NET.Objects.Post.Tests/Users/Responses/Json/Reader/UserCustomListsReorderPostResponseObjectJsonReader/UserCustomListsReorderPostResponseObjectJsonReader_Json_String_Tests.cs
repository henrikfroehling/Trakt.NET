namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserCustomListsReorderPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().Be(6);
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktUserCustomListsReorderPostResponse.Should().NotBeNull();
            traktUserCustomListsReorderPostResponse.Updated.Should().BeNull();
            traktUserCustomListsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            Func<Task<ITraktUserCustomListsReorderPostResponse>> traktUserCustomListsReorderPostResponse = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktUserCustomListsReorderPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostResponseObjectJsonReader();
            var traktUserCustomListsReorderPostResponse = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktUserCustomListsReorderPostResponse.Should().BeNull();
        }
    }
}
