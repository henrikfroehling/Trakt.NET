namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCastMembers.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(default(string));
            traktCastMembers.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberArrayJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CastMemberArrayJsonReader();

            var traktCastMembers = await jsonReader.ReadArrayAsync(string.Empty);
            traktCastMembers.Should().BeNull();
        }
    }
}
