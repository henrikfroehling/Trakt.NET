namespace TraktNet.Tests.Objects.Basic.Json.Reader.CastAndCrewArrayJsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastAndCrewArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCastAndCrews.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

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
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

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

                castMemberItems = items[1].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Character.Should().Be("Joe Brody");
                castMemberItems[0].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Character.Should().Be("Joe Brody");
                castMemberItems[0].Person.Should().BeNull();

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
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().BeNull();

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
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

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

                castMemberItems = items[1].Cast.ToArray();

                castMemberItems[0].Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().BeNull();

                castMemberItems = items[1].Cast.ToArray();

                castMemberItems[0].Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();
            IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCastAndCrews.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CastAndCrewArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCastAndCrews.Should().BeNull();
            }
        }
    }
}
