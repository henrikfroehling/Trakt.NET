namespace TraktNet.Objects.Post.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Basic.JsonWriter")]
    public partial class ListItemsReorderPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
            ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), listItemsReorderPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, listItemsReorderPost);
                json.Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
            }
        }
    }
}
