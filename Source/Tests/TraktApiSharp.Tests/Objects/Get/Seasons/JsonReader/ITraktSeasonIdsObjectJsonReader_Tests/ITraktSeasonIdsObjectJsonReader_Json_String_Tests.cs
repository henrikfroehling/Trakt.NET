namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(default(string));
            traktSeasonIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktSeasonIds.Should().BeNull();
        }
    }
}
