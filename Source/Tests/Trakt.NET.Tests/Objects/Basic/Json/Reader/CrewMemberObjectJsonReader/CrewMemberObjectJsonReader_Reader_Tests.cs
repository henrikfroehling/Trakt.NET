namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CrewMemberObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCrewMember.Should().NotBeNull();
                traktCrewMember.Job.Should().Be("Director");
                traktCrewMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCrewMember.Should().NotBeNull();
                traktCrewMember.Job.Should().Be("Director");
                traktCrewMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCrewMember.Should().NotBeNull();
                traktCrewMember.Job.Should().BeNull();
                traktCrewMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            var traktCrewMember = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCrewMember.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewMemberObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CrewMemberObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCrewMember = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCrewMember.Should().BeNull();
            }
        }
    }
}
