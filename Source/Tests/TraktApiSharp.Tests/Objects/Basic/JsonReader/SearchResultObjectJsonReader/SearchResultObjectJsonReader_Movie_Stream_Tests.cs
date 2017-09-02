namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_COMPLETE.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_1.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_2.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_3.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_4.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);

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
