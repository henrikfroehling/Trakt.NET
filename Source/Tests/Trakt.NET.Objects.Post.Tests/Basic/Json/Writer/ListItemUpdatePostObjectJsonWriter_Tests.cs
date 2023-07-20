namespace TraktNet.Objects.Post.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Basic.JsonWriter")]
    public class ListItemUpdatePostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ListItemUpdatePostObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktListItemUpdatePost listItemUpdatePost = new TraktListItemUpdatePost
            {
                Notes = "This is a great movie!"
            };

            var traktJsonWriter = new ListItemUpdatePostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemUpdatePost);
            json.Should().Be(@"{""notes"":""This is a great movie!""}");
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonWriter_WriteObject_Object_Complete_Notes_Empty()
        {
            ITraktListItemUpdatePost listItemUpdatePost = new TraktListItemUpdatePost
            {
                Notes = ""
            };

            var traktJsonWriter = new ListItemUpdatePostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemUpdatePost);
            json.Should().Be(@"{""notes"":""""}");
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonWriter_WriteObject_Object_Complete_Notes_Null()
        {
            ITraktListItemUpdatePost listItemUpdatePost = new TraktListItemUpdatePost
            {
                Notes = null
            };

            var traktJsonWriter = new ListItemUpdatePostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(listItemUpdatePost);
            json.Should().Be(@"{""notes"":null}");
        }
    }
}
