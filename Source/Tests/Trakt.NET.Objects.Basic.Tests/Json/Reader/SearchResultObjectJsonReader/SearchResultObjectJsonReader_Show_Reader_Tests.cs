namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().NotBeNull();
                traktSearchResultItem.Show.Title.Should().Be("Game of Thrones");
                traktSearchResultItem.Show.Year.Should().Be(2011);
                traktSearchResultItem.Show.Ids.Should().NotBeNull();
                traktSearchResultItem.Show.Ids.Trakt.Should().Be(1390U);
                traktSearchResultItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktSearchResultItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktSearchResultItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktSearchResultItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktSearchResultItem.Show.Ids.TvRage.Should().Be(24493U);

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Show);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Show.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
            }
        }
    }
}
