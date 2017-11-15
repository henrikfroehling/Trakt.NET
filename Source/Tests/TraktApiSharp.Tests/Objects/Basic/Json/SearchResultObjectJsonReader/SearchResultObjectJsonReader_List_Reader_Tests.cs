namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.List.Should().NotBeNull();
                traktSearchResultItem.List.Name.Should().Be("Star Wars in machete order");
                traktSearchResultItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                traktSearchResultItem.List.Privacy.Should().Be(TraktAccessScope.Public);
                traktSearchResultItem.List.DisplayNumbers.Should().BeTrue();
                traktSearchResultItem.List.AllowComments.Should().BeFalse();
                traktSearchResultItem.List.SortBy.Should().Be("rank");
                traktSearchResultItem.List.SortHow.Should().Be("asc");
                traktSearchResultItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                traktSearchResultItem.List.ItemCount.Should().Be(5);
                traktSearchResultItem.List.CommentCount.Should().Be(1);
                traktSearchResultItem.List.Likes.Should().Be(2);
                traktSearchResultItem.List.Ids.Should().NotBeNull();
                traktSearchResultItem.List.Ids.Trakt.Should().Be(55);
                traktSearchResultItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                traktSearchResultItem.List.User.Should().NotBeNull();
                traktSearchResultItem.List.User.Username.Should().Be("sean");
                traktSearchResultItem.List.User.IsPrivate.Should().BeFalse();
                traktSearchResultItem.List.User.Name.Should().Be("Sean Rudford");
                traktSearchResultItem.List.User.IsVIP.Should().BeTrue();
                traktSearchResultItem.List.User.IsVIP_EP.Should().BeFalse();
                traktSearchResultItem.List.User.Ids.Should().NotBeNull();
                traktSearchResultItem.List.User.Ids.Slug.Should().Be("sean");

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().Be(TraktSearchResultType.List);
                traktSearchResultItem.Score.Should().Be(46.29501f);
                traktSearchResultItem.List.Should().BeNull();

                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_List_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SearchResultObjectJsonReader();

            using (var reader = new StringReader(TYPE_LIST_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSearchResultItem.Should().NotBeNull();
                traktSearchResultItem.Type.Should().BeNull();
                traktSearchResultItem.Score.Should().BeNull();
                traktSearchResultItem.List.Should().BeNull();
                traktSearchResultItem.Movie.Should().BeNull();
                traktSearchResultItem.Show.Should().BeNull();
                traktSearchResultItem.Episode.Should().BeNull();
                traktSearchResultItem.Person.Should().BeNull();
            }
        }
    }
}
