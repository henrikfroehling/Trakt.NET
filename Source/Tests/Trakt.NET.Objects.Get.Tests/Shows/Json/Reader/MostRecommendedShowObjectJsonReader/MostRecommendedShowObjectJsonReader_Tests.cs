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
    public partial class MostRecommendedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().Be(155291);
                traktMostRecommendedShow.Show.Should().NotBeNull();
                traktMostRecommendedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostRecommendedShow.Show.Year.Should().Be(2011);
                traktMostRecommendedShow.Show.Ids.Should().NotBeNull();
                traktMostRecommendedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostRecommendedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostRecommendedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostRecommendedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostRecommendedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostRecommendedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().Be(155291);
                traktMostRecommendedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().BeNull();
                traktMostRecommendedShow.Show.Should().NotBeNull();
                traktMostRecommendedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostRecommendedShow.Show.Year.Should().Be(2011);
                traktMostRecommendedShow.Show.Ids.Should().NotBeNull();
                traktMostRecommendedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostRecommendedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostRecommendedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostRecommendedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostRecommendedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostRecommendedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().BeNull();
                traktMostRecommendedShow.Show.Should().NotBeNull();
                traktMostRecommendedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostRecommendedShow.Show.Year.Should().Be(2011);
                traktMostRecommendedShow.Show.Ids.Should().NotBeNull();
                traktMostRecommendedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostRecommendedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostRecommendedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostRecommendedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostRecommendedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostRecommendedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().Be(155291);
                traktMostRecommendedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostRecommendedShow.Should().NotBeNull();
                traktMostRecommendedShow.UserCount.Should().BeNull();
                traktMostRecommendedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();
            Func<Task<ITraktMostRecommendedShow>> traktMostRecommendedShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktMostRecommendedShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostRecommendedShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostRecommendedShowObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktMostRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktMostRecommendedShow.Should().BeNull();
        }
    }
}
