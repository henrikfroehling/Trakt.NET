namespace Trakt.NET.Objects.Tests.Post.Users.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public void Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
            ITraktUserCustomListsReorderPost traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktUserCustomListsReorderPost);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktUserCustomListsReorderPost traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktUserCustomListsReorderPost);
                stringWriter.ToString().Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
            }
        }
    }
}
