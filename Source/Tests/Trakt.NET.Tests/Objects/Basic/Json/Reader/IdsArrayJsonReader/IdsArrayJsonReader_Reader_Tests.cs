namespace TraktNet.Tests.Objects.Basic.Json.Reader.IdsArrayJsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class IdsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);
                multipleTraktIds.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(1390);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(1390);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktIds.Should().NotBeNull();
                ITraktIds[] ids = multipleTraktIds.ToArray();

                ids[0].Should().NotBeNull();
                ids[0].Trakt.Should().Be(0);
                ids[0].Slug.Should().Be("game-of-thrones");
                ids[0].Tvdb.Should().Be(121361U);
                ids[0].Imdb.Should().Be("tt0944947");
                ids[0].Tmdb.Should().Be(1399U);
                ids[0].TvRage.Should().Be(24493U);

                ids[1].Should().NotBeNull();
                ids[1].Trakt.Should().Be(0);
                ids[1].Slug.Should().Be("game-of-thrones");
                ids[1].Tvdb.Should().Be(121361U);
                ids[1].Imdb.Should().Be("tt0944947");
                ids[1].Tmdb.Should().Be(1399U);
                ids[1].TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new IdsArrayJsonReader();
            IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            multipleTraktIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new IdsArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktIds> multipleTraktIds = await traktJsonReader.ReadArrayAsync(jsonReader);
                multipleTraktIds.Should().BeNull();
            }
        }
    }
}
