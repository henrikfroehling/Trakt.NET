namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSearchResults.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Show_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SearchResultArrayJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Show.Should().NotBeNull();
                searchResults[0].Show.Title.Should().Be("Game of Thrones");
                searchResults[0].Show.Year.Should().Be(2011);
                searchResults[0].Show.Ids.Should().NotBeNull();
                searchResults[0].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[0].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[0].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[0].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[0].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].Person.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Show);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Show.Should().NotBeNull();
                searchResults[1].Show.Title.Should().Be("Game of Thrones");
                searchResults[1].Show.Year.Should().Be(2011);
                searchResults[1].Show.Ids.Should().NotBeNull();
                searchResults[1].Show.Ids.Trakt.Should().Be(1390U);
                searchResults[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                searchResults[1].Show.Ids.Tvdb.Should().Be(121361U);
                searchResults[1].Show.Ids.Imdb.Should().Be("tt0944947");
                searchResults[1].Show.Ids.Tmdb.Should().Be(1399U);
                searchResults[1].Show.Ids.TvRage.Should().Be(24493U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].Person.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }
    }
}
