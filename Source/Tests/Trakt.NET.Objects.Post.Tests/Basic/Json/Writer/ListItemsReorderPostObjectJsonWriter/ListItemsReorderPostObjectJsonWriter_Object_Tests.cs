namespace TraktNet.Objects.Post.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Basic.JsonWriter")]
    public partial class ListItemsReorderPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemsReorderPost);
            json.Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
        }
    }
}
