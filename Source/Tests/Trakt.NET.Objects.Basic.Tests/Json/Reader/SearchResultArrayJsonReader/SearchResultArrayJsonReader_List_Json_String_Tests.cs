namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class SearchResultArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktSearchResults.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_COMPLETE);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().Be(46.29501f);
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().Be(46.29501f);
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_INCOMPLETE_1);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().Be(46.29501f);
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().BeNull();
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_INCOMPLETE_2);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().BeNull();
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().Be(46.29501f);
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_NOT_VALID_1);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().BeNull();
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().Be(46.29501f);
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_NOT_VALID_2);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().Be(46.29501f);
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().BeNull();
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultArrayJsonReader_List_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktSearchResult>();
            IEnumerable<ITraktSearchResult> traktSearchResults = await jsonReader.ReadArrayAsync(TYPE_LIST_JSON_NOT_VALID_3);

            traktSearchResults.Should().NotBeNull();
            ITraktSearchResult[] searchResults = traktSearchResults.ToArray();

            searchResults[0].Should().NotBeNull();
            searchResults[0].Type.Should().Be(TraktSearchResultType.List);
            searchResults[0].Score.Should().BeNull();
            searchResults[0].List.Should().NotBeNull();
            searchResults[0].List.Name.Should().Be("Star Wars in machete order");
            searchResults[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[0].List.DisplayNumbers.Should().BeTrue();
            searchResults[0].List.AllowComments.Should().BeFalse();
            searchResults[0].List.SortBy.Should().Be("rank");
            searchResults[0].List.SortHow.Should().Be("asc");
            searchResults[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[0].List.ItemCount.Should().Be(5);
            searchResults[0].List.CommentCount.Should().Be(1);
            searchResults[0].List.Likes.Should().Be(2);
            searchResults[0].List.Ids.Should().NotBeNull();
            searchResults[0].List.Ids.Trakt.Should().Be(55);
            searchResults[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[0].List.User.Should().NotBeNull();
            searchResults[0].List.User.Username.Should().Be("sean");
            searchResults[0].List.User.IsPrivate.Should().BeFalse();
            searchResults[0].List.User.Name.Should().Be("Sean Rudford");
            searchResults[0].List.User.IsVIP.Should().BeTrue();
            searchResults[0].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[0].List.User.Ids.Should().NotBeNull();
            searchResults[0].List.User.Ids.Slug.Should().Be("sean");

            searchResults[0].Movie.Should().BeNull();
            searchResults[0].Show.Should().BeNull();
            searchResults[0].Episode.Should().BeNull();
            searchResults[0].Person.Should().BeNull();

            searchResults[1].Should().NotBeNull();
            searchResults[1].Type.Should().Be(TraktSearchResultType.List);
            searchResults[1].Score.Should().BeNull();
            searchResults[1].List.Should().NotBeNull();
            searchResults[1].List.Name.Should().Be("Star Wars in machete order");
            searchResults[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            searchResults[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
            searchResults[1].List.DisplayNumbers.Should().BeTrue();
            searchResults[1].List.AllowComments.Should().BeFalse();
            searchResults[1].List.SortBy.Should().Be("rank");
            searchResults[1].List.SortHow.Should().Be("asc");
            searchResults[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            searchResults[1].List.ItemCount.Should().Be(5);
            searchResults[1].List.CommentCount.Should().Be(1);
            searchResults[1].List.Likes.Should().Be(2);
            searchResults[1].List.Ids.Should().NotBeNull();
            searchResults[1].List.Ids.Trakt.Should().Be(55);
            searchResults[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            searchResults[1].List.User.Should().NotBeNull();
            searchResults[1].List.User.Username.Should().Be("sean");
            searchResults[1].List.User.IsPrivate.Should().BeFalse();
            searchResults[1].List.User.Name.Should().Be("Sean Rudford");
            searchResults[1].List.User.IsVIP.Should().BeTrue();
            searchResults[1].List.User.IsVIP_EP.Should().BeFalse();
            searchResults[1].List.User.Ids.Should().NotBeNull();
            searchResults[1].List.User.Ids.Slug.Should().Be("sean");

            searchResults[1].Movie.Should().BeNull();
            searchResults[1].Show.Should().BeNull();
            searchResults[1].Episode.Should().BeNull();
            searchResults[1].Person.Should().BeNull();
        }
    }
}
