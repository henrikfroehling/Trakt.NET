namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonReader")]
    public partial class MovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieAliasObjectJsonReader();
            Func<Task<ITraktMovieAlias>> traktMovieAlias = () => jsonReader.ReadObjectAsync(default(string));
            await traktMovieAlias.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovieAlias.Should().BeNull();
        }
    }
}
