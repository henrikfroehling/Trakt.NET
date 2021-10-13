namespace TraktNet.Objects.Post.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Users;
    using Xunit;

    [Category("Objects.Post.Users.JsonWriter")]
    public partial class UserCustomListsReorderPostArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<TraktUserCustomListsReorderPost>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPosts);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<ITraktUserCustomListsReorderPost>
            {
                new TraktUserCustomListsReorderPost
                {
                    Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPosts);
            json.Should().Be(@"[{""rank"":[823,224,88768,356456,245,2,890]}]");
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<ITraktUserCustomListsReorderPost>
            {
                new TraktUserCustomListsReorderPost
                {
                    Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
                },
                new TraktUserCustomListsReorderPost
                {
                    Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
            string json = await traktJsonWriter.WriteArrayAsync(traktUserCustomListsReorderPosts);
            json.Should().Be(@"[{""rank"":[823,224,88768,356456,245,2,890]}," +
                             @"{""rank"":[823,224,88768,356456,245,2,890]}]");
        }
    }
}
