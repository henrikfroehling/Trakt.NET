namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCastMembers.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().Be("Joe Brody");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().NotBeNull();
                items[1].Person.Name.Should().Be("Samuel L.Jackson");
                items[1].Person.Ids.Should().NotBeNull();
                items[1].Person.Ids.Trakt.Should().Be(9486U);
                items[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                items[1].Person.Ids.Imdb.Should().Be("nm0000168");
                items[1].Person.Ids.Tmdb.Should().Be(2231U);
                items[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().NotBeNull();
                items[1].Person.Name.Should().Be("Samuel L.Jackson");
                items[1].Person.Ids.Should().NotBeNull();
                items[1].Person.Ids.Trakt.Should().Be(9486U);
                items[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                items[1].Person.Ids.Imdb.Should().Be("nm0000168");
                items[1].Person.Ids.Tmdb.Should().Be(2231U);
                items[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().Be("Joe Brody");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().NotBeNull();
                items[1].Person.Name.Should().Be("Samuel L.Jackson");
                items[1].Person.Ids.Should().NotBeNull();
                items[1].Person.Ids.Trakt.Should().Be(9486U);
                items[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                items[1].Person.Ids.Imdb.Should().Be("nm0000168");
                items[1].Person.Ids.Tmdb.Should().Be(2231U);
                items[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().Be("Joe Brody");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastMembers.Should().NotBeNull();
                var items = traktCastMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Character.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Character.Should().Be("Jules Winfield");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCastMembers.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CastMemberArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMembers = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCastMembers.Should().BeNull();
            }
        }
    }
}
