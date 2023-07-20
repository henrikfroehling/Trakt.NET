namespace TraktNet.Objects.Post.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.JsonReader")]
    public partial class ListItemUpdatePostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListItemUpdatePostObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var listItemUpdatePost = await traktJsonReader.ReadObjectAsync(jsonReader);

            listItemUpdatePost.Should().NotBeNull();
            listItemUpdatePost.Notes.Should().Be("This is a great movie!");
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ListItemUpdatePostObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var listItemUpdatePost = await traktJsonReader.ReadObjectAsync(jsonReader);

            listItemUpdatePost.Should().NotBeNull();
            listItemUpdatePost.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListItemUpdatePostObjectJsonReader();
            Func<Task<ITraktListItemUpdatePost>> listItemUpdatePost = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await listItemUpdatePost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemUpdatePostObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListItemUpdatePostObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var listItemUpdatePost = await traktJsonReader.ReadObjectAsync(jsonReader);
            listItemUpdatePost.Should().BeNull();
        }
    }
}
