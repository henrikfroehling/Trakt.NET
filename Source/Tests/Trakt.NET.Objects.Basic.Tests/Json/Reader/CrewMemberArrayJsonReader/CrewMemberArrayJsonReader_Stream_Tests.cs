﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CrewMemberArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);
                traktCrewMembers.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
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
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
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
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
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
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);

                traktCrewMembers.Should().NotBeNull();
                var items = traktCrewMembers.ToArray();

                items[0].Should().NotBeNull();
                items[0].Jobs.Should().BeNull();
                items[0].Person.Should().NotBeNull();
                items[0].Person.Name.Should().Be("Bryan Cranston");
                items[0].Person.Ids.Should().NotBeNull();
                items[0].Person.Ids.Trakt.Should().Be(297737U);
                items[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                items[0].Person.Ids.Imdb.Should().Be("nm0186505");
                items[0].Person.Ids.Tmdb.Should().Be(17419U);
                items[0].Person.Ids.TvRage.Should().Be(1797U);

                items[1].Should().NotBeNull();
                items[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                items[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();
            Func<Task<IList<ITraktCrewMember>>> traktCrewMembers = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktCrewMembers.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCrewMember>();

            using (var stream = string.Empty.ToStream())
            {
                var traktCrewMembers = await jsonReader.ReadArrayAsync(stream);
                traktCrewMembers.Should().BeNull();
            }
        }
    }
}
