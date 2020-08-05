namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CastMemberObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            traktCastMember.Person.Should().NotBeNull();
            traktCastMember.Person.Name.Should().Be("Bryan Cranston");
            traktCastMember.Person.Ids.Should().NotBeNull();
            traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().BeNull();
            traktCastMember.Person.Should().NotBeNull();
            traktCastMember.Person.Name.Should().Be("Bryan Cranston");
            traktCastMember.Person.Ids.Should().NotBeNull();
            traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            traktCastMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().BeNull();
            traktCastMember.Person.Should().NotBeNull();
            traktCastMember.Person.Name.Should().Be("Bryan Cranston");
            traktCastMember.Person.Ids.Should().NotBeNull();
            traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
            traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
            traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
            traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            traktCastMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCastMember.Should().NotBeNull();
            traktCastMember.Characters.Should().BeNull();
            traktCastMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(default(string));
            traktCastMember.Should().BeNull();
        }

        [Fact]
        public async Task Test_CastMemberObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(string.Empty);
            traktCastMember.Should().BeNull();
        }
    }
}
