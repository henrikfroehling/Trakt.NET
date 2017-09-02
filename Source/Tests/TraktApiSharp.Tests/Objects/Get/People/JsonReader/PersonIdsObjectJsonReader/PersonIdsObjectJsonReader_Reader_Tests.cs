namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktPersonIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktPersonIds.Should().BeNull();
            }
        }
    }
}
