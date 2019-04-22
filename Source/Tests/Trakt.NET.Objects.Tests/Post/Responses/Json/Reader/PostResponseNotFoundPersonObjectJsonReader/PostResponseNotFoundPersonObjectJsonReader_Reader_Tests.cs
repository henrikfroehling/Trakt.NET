namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundPerson.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Trakt.Should().Be(297737U);
                postResponseNotFoundPerson.Ids.Slug.Should().Be("bryan-cranston");
                postResponseNotFoundPerson.Ids.Imdb.Should().Be("nm0186505");
                postResponseNotFoundPerson.Ids.Tmdb.Should().Be(17419U);
                postResponseNotFoundPerson.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundPerson.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            postResponseNotFoundPerson.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundPerson.Should().BeNull();
            }
        }
    }
}
