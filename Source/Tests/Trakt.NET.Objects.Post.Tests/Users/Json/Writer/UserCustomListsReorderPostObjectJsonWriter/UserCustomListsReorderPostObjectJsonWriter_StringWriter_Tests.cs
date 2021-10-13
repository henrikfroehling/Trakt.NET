namespace TraktNet.Objects.Post.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Users.JsonWriter")]
    public partial class UserCustomListsReorderPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
            ITraktUserCustomListsReorderPost traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktUserCustomListsReorderPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktUserCustomListsReorderPost traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktUserCustomListsReorderPost);
                json.Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
            }
        }
    }
}
