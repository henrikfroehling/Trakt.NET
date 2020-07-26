namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);
                traktSearchResults.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Movie_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Movie.Should().NotBeNull();
                searchResults[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[0].Movie.Year.Should().Be(2015);
                searchResults[0].Movie.Ids.Should().NotBeNull();
                searchResults[0].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[0].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();
                searchResults[0].Person.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Movie);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Movie.Should().NotBeNull();
                searchResults[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                searchResults[1].Movie.Year.Should().Be(2015);
                searchResults[1].Movie.Ids.Should().NotBeNull();
                searchResults[1].Movie.Ids.Trakt.Should().Be(94024U);
                searchResults[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                searchResults[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                searchResults[1].Movie.Ids.Tmdb.Should().Be(140607U);

                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
            }
        }
    }
}
