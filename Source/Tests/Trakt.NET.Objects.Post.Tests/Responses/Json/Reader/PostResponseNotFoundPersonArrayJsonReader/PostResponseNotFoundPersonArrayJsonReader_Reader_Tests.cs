namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundPersons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundPersons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundPersons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundPersons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundPerson = notFoundPersons.ToArray();

                notFoundPerson[0].Should().NotBeNull();
                notFoundPerson[0].Ids.Should().NotBeNull();
                notFoundPerson[0].Ids.Trakt.Should().Be(297737U);
                notFoundPerson[0].Ids.Slug.Should().Be("bryan-cranston");
                notFoundPerson[0].Ids.Imdb.Should().Be("nm0186505");
                notFoundPerson[0].Ids.Tmdb.Should().Be(17419U);
                notFoundPerson[0].Ids.TvRage.Should().Be(1797U);

                notFoundPerson[1].Should().NotBeNull();
                notFoundPerson[1].Ids.Should().NotBeNull();
                notFoundPerson[1].Ids.Trakt.Should().Be(9486U);
                notFoundPerson[1].Ids.Slug.Should().Be("samuel-l-jackson");
                notFoundPerson[1].Ids.Imdb.Should().Be("nm0000168");
                notFoundPerson[1].Ids.Tmdb.Should().Be(2231U);
                notFoundPerson[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundPersons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundPersons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundPerson = notFoundPersons.ToArray();

                notFoundPerson[0].Should().NotBeNull();
                notFoundPerson[0].Ids.Should().NotBeNull();
                notFoundPerson[0].Ids.Trakt.Should().Be(297737U);
                notFoundPerson[0].Ids.Slug.Should().Be("bryan-cranston");
                notFoundPerson[0].Ids.Imdb.Should().Be("nm0186505");
                notFoundPerson[0].Ids.Tmdb.Should().Be(17419U);
                notFoundPerson[0].Ids.TvRage.Should().Be(1797U);

                notFoundPerson[1].Should().NotBeNull();
                notFoundPerson[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            notFoundPersons.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundPersons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundPersons.Should().BeNull();
            }
        }
    }
}
