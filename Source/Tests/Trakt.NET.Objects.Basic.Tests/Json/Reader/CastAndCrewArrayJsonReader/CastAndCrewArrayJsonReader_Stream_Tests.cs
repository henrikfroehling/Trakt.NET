namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastAndCrewArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);
                traktCastAndCrews.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                castMemberItems[0].Person.Should().BeNull();

                items[1].Crew.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                castMemberItems[0].Person.Should().BeNull();

                items[0].Crew.Should().BeNull();

                castMemberItems = items[1].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();

                items[0].Cast.Should().BeNull();
                items[0].Crew.Should().BeNull();

                ITraktCastMember[] castMemberItems = items[1].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                ITraktCastMember[] castMemberItems = items[0].Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
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
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);

                traktCastAndCrews.Should().NotBeNull();
                ITraktCastAndCrew[] items = traktCastAndCrews.ToArray();
                items[0].Cast.Should().BeNull();
                items[0].Crew.Should().BeNull();
                items[1].Cast.Should().BeNull();
                items[1].Crew.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();
            Func<Task<IEnumerable<ITraktCastAndCrew>>> traktCastAndCrews = () =>jsonReader.ReadArrayAsync(default(Stream));
            traktCastAndCrews.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CastAndCrewArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCastAndCrew>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktCastAndCrew> traktCastAndCrews = await jsonReader.ReadArrayAsync(stream);
                traktCastAndCrews.Should().BeNull();
            }
        }
    }
}
