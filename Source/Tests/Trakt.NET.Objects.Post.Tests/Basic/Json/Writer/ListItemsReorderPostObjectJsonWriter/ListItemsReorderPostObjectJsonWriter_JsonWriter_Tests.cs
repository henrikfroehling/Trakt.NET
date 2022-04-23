namespace TraktNet.Objects.Post.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
            ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), listItemsReorderPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ListItemsReorderPostObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, listItemsReorderPost);
                stringWriter.ToString().Should().Be(@"{""rank"":[823,224,88768,356456,245,2,890]}");
            }
        }
    }
}
