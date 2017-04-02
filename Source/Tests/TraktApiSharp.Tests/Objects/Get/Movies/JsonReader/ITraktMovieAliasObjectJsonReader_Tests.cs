namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public class ITraktMovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMovieAliasObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMovieAliasObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMovieAlias>));
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(default(string));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovieAlias.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";
    }
}
