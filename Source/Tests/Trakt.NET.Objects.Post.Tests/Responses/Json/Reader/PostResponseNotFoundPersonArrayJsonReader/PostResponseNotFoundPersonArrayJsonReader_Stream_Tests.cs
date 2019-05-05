namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var notFoundPersons = await jsonReader.ReadArrayAsync(stream);
                notFoundPersons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var notFoundPersons = await jsonReader.ReadArrayAsync(stream);
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
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var notFoundPersons = await jsonReader.ReadArrayAsync(stream);
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
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            var notFoundPersons = await jsonReader.ReadArrayAsync(default(Stream));
            notFoundPersons.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundPersonArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var notFoundPersons = await jsonReader.ReadArrayAsync(stream);
                notFoundPersons.Should().BeNull();
            }
        }
    }
}
