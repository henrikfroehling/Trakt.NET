namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCastMember.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CastMemberObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCastMember = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCastMember.Should().BeNull();
            }
        }
    }
}
