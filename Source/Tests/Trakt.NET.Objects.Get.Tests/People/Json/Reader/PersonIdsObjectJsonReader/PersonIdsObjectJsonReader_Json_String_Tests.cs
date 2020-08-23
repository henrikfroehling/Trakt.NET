namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonIdsObjectJsonReader();
            Func<Task<ITraktPersonIds>> traktPersonIds = () => jsonReader.ReadObjectAsync(default(string));
            traktPersonIds.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktPersonIds.Should().BeNull();
        }
    }
}
