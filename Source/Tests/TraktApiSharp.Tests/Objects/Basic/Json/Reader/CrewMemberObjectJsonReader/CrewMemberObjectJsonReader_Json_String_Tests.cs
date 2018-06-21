namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CrewMemberObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().Be("Director");
            traktCrewMember.Person.Should().NotBeNull();
            traktCrewMember.Person.Name.Should().Be("Bryan Cranston");
            traktCrewMember.Person.Ids.Should().NotBeNull();
            traktCrewMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCrewMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCrewMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCrewMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCrewMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().BeNull();
            traktCrewMember.Person.Should().NotBeNull();
            traktCrewMember.Person.Name.Should().Be("Bryan Cranston");
            traktCrewMember.Person.Ids.Should().NotBeNull();
            traktCrewMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCrewMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCrewMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCrewMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCrewMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().Be("Director");
            traktCrewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().BeNull();
            traktCrewMember.Person.Should().NotBeNull();
            traktCrewMember.Person.Name.Should().Be("Bryan Cranston");
            traktCrewMember.Person.Ids.Should().NotBeNull();
            traktCrewMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCrewMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCrewMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCrewMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCrewMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().Be("Director");
            traktCrewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCrewMember.Should().NotBeNull();
            traktCrewMember.Job.Should().BeNull();
            traktCrewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(default(string));
            traktCrewMember.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await jsonReader.ReadObjectAsync(string.Empty);
            traktCrewMember.Should().BeNull();
        }
    }
}
