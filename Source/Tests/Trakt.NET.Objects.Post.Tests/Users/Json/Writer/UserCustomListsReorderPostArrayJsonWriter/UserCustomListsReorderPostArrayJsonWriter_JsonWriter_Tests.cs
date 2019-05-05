namespace TraktNet.Objects.Post.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Users;
    using Xunit;

    [Category("Objects.Post.Users.JsonWriter")]
    public partial class UserCustomListsReorderPostArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<TraktUserCustomListsReorderPost>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktUserCustomListsReorderPosts);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<TraktUserCustomListsReorderPost>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPosts);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktUserCustomListsReorderPost> traktUserCustomListsReorderPosts = new List<ITraktUserCustomListsReorderPost>
            {
                new TraktUserCustomListsReorderPost
                {
                    Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPosts);
                stringWriter.ToString().Should().Be(@"[{""rank"":[823,224,88768,356456,245,2,890]}]");
            }
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktUserCustomListsReorderPost>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktUserCustomListsReorderPosts);
                stringWriter.ToString().Should().Be(@"[{""rank"":[823,224,88768,356456,245,2,890]}," +
                                                    @"{""rank"":[823,224,88768,356456,245,2,890]}]");
            }
        }
    }
}
