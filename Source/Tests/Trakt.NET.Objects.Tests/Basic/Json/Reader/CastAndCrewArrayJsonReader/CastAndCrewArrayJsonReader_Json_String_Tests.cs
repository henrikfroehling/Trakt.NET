namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastAndCrewArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCastAndCrews.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
            ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[0].Crew.Should().BeNull();

            castMemberItems = items[1].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
            ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[0].Crew.Should().BeNull();

            castMemberItems = items[1].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().BeNull();

            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
            ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().BeNull();

            items[0].Crew.Should().BeNull();

            castMemberItems = items[1].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();

            items[0].Cast.Should().BeNull();
            items[0].Crew.Should().BeNull();

            ITraktCastMember[] castMemberItems = items[1].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
            ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

            castMemberItems[0].Should().NotBeNull();
            castMemberItems[0].Character.Should().Be("Joe Brody");
            castMemberItems[0].Person.Should().NotBeNull();
            castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
            castMemberItems[0].Person.Ids.Should().NotBeNull();
            castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
            castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
            castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
            castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
            castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

            items[1].Cast.Should().BeNull();
            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktCastAndCrews.Should().NotBeNull();
            ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
            items[0].Cast.Should().BeNull();
            items[0].Crew.Should().BeNull();
            items[1].Cast.Should().BeNull();
            items[1].Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(default(string));
            traktCastAndCrews.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(string.Empty);
            traktCastAndCrews.Should().BeNull();
        }
    }
}
