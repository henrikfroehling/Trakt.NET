namespace TraktApiSharp.Tests.Objects.Post.Responses.Json
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.Json;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            notFoundPersons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
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

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID);
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

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(default(string));
            notFoundPersons.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(string.Empty);
            notFoundPersons.Should().BeNull();
        }
    }
}
