namespace TraktNet.Objects.Post.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.JsonReader")]
    public partial class UserCustomListsReorderPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();
            var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktUserCustomListsReorderPost.Should().NotBeNull();
            traktUserCustomListsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
            traktUserCustomListsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();
            var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktUserCustomListsReorderPost.Should().NotBeNull();
            traktUserCustomListsReorderPost.Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();
            Func<Task<ITraktUserCustomListsReorderPost>> traktUserCustomListsReorderPost = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktUserCustomListsReorderPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new UserCustomListsReorderPostObjectJsonReader();
            var traktUserCustomListsReorderPost = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktUserCustomListsReorderPost.Should().BeNull();
        }
    }
}
