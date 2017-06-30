namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundPersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktPostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktPostResponseNotFoundPersonObjectJsonReader();

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
        public async Task Test_TraktPostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new TraktPostResponseNotFoundPersonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundPerson.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktPostResponseNotFoundPersonObjectJsonReader();

            var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            postResponseNotFoundPerson.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundPersonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktPostResponseNotFoundPersonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundPerson = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundPerson.Should().BeNull();
            }
        }
    }
}
