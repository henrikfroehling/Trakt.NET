namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonReader")]
    public partial class MostFavoritedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().Be(155291);
                traktMostFavoritedShow.Show.Should().NotBeNull();
                traktMostFavoritedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostFavoritedShow.Show.Year.Should().Be(2011);
                traktMostFavoritedShow.Show.Ids.Should().NotBeNull();
                traktMostFavoritedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostFavoritedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostFavoritedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostFavoritedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostFavoritedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostFavoritedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().Be(155291);
                traktMostFavoritedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().BeNull();
                traktMostFavoritedShow.Show.Should().NotBeNull();
                traktMostFavoritedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostFavoritedShow.Show.Year.Should().Be(2011);
                traktMostFavoritedShow.Show.Ids.Should().NotBeNull();
                traktMostFavoritedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostFavoritedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostFavoritedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostFavoritedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostFavoritedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostFavoritedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().BeNull();
                traktMostFavoritedShow.Show.Should().NotBeNull();
                traktMostFavoritedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostFavoritedShow.Show.Year.Should().Be(2011);
                traktMostFavoritedShow.Show.Ids.Should().NotBeNull();
                traktMostFavoritedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostFavoritedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostFavoritedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostFavoritedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostFavoritedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostFavoritedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().Be(155291);
                traktMostFavoritedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostFavoritedShow.Should().NotBeNull();
                traktMostFavoritedShow.UserCount.Should().BeNull();
                traktMostFavoritedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();
            Func<Task<ITraktMostFavoritedShow>> traktMostFavoritedShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktMostFavoritedShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostFavoritedShowObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktMostFavoritedShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktMostFavoritedShow.Should().BeNull();
        }
    }
}
