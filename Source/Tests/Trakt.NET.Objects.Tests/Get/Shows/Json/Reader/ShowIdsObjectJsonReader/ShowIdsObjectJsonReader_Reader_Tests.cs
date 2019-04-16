namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(1390);
                traktShowIds.Slug.Should().Be("game-of-thrones");
                traktShowIds.Tvdb.Should().Be(121361U);
                traktShowIds.Imdb.Should().Be("tt0944947");
                traktShowIds.Tmdb.Should().Be(1399U);
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowIds.Should().NotBeNull();
                traktShowIds.Trakt.Should().Be(0);
                traktShowIds.Slug.Should().BeNull();
                traktShowIds.Tvdb.Should().BeNull();
                traktShowIds.Imdb.Should().BeNull();
                traktShowIds.Tmdb.Should().BeNull();
                traktShowIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktShowIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ShowIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktShowIds.Should().BeNull();
            }
        }
    }
}
