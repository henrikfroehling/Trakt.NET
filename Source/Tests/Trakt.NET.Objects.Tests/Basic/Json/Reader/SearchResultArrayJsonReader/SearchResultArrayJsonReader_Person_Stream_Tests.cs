namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);
                traktSearchResults.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().Be(46.29501f);
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().Be(46.29501f);
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_Person_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SearchResultArrayJsonReader();

            using (var stream = TYPE_PERSON_JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(stream);

                traktSearchResults.Should().NotBeNull();
                ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

                searchResults[0].Should().NotBeNull();
                searchResults[0].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[0].Score.Should().BeNull();
                searchResults[0].Person.Should().NotBeNull();
                searchResults[0].Person.Name.Should().Be("Bryan Cranston");
                searchResults[0].Person.Ids.Should().NotBeNull();
                searchResults[0].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[0].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[0].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[0].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[0].Movie.Should().BeNull();
                searchResults[0].Show.Should().BeNull();
                searchResults[0].Episode.Should().BeNull();
                searchResults[0].List.Should().BeNull();

                searchResults[1].Should().NotBeNull();
                searchResults[1].Type.Should().Be(TraktSearchResultType.Person);
                searchResults[1].Score.Should().BeNull();
                searchResults[1].Person.Should().NotBeNull();
                searchResults[1].Person.Name.Should().Be("Bryan Cranston");
                searchResults[1].Person.Ids.Should().NotBeNull();
                searchResults[1].Person.Ids.Trakt.Should().Be(297737U);
                searchResults[1].Person.Ids.Slug.Should().Be("bryan-cranston");
                searchResults[1].Person.Ids.Imdb.Should().Be("nm0186505");
                searchResults[1].Person.Ids.Tmdb.Should().Be(17419U);
                searchResults[1].Person.Ids.TvRage.Should().Be(1797U);

                searchResults[1].Movie.Should().BeNull();
                searchResults[1].Show.Should().BeNull();
                searchResults[1].Episode.Should().BeNull();
                searchResults[1].List.Should().BeNull();
            }
        }
    }
}
