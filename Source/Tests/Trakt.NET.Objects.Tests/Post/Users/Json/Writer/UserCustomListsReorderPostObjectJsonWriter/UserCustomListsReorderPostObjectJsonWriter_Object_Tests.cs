namespace Trakt.NET.Objects.Tests.Post.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Users.JsonWriter")]
    public partial class UserCustomListsReorderPostObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCustomListsReorderPostObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktUserCustomListsReorderPost traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            var traktJsonWriter = new UserCustomListsReorderPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserCustomListsReorderPost);
            json.Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
        }
    }
}
