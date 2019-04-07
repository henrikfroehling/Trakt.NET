namespace TraktNet.Objects.Tests.Basic.Json.Reader
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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().BeNull();

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().BeNull();

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Movie.Should().NotBeNull();
                traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktSearchResultItem.Movie.Year.Should().Be(2015);
                traktSearchResultItem.Movie.Ids.Should().NotBeNull();
                traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.Movie.Should().BeNull();

                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }
    }
}
