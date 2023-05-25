namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CommentItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);
                traktCommentItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().NotBeNull();
                commentItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[0].Movie.Year.Should().Be(2015);
                commentItems[0].Movie.Ids.Should().NotBeNull();
                commentItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[0].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[0].Show.Should().NotBeNull();
                commentItems[0].Show.Title.Should().Be("Game of Thrones");
                commentItems[0].Show.Year.Should().Be(2011);
                commentItems[0].Show.Ids.Should().NotBeNull();
                commentItems[0].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[0].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[0].Season.Should().NotBeNull();
                commentItems[0].Season.Number.Should().Be(1);
                commentItems[0].Season.Ids.Should().NotBeNull();
                commentItems[0].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[0].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[0].Episode.Should().NotBeNull();
                commentItems[0].Episode.SeasonNumber.Should().Be(1);
                commentItems[0].Episode.Number.Should().Be(1);
                commentItems[0].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[0].Episode.Ids.Should().NotBeNull();
                commentItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[0].List.Should().NotBeNull();
                commentItems[0].List.Name.Should().Be("Star Wars in machete order");
                commentItems[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[0].List.DisplayNumbers.Should().BeTrue();
                commentItems[0].List.AllowComments.Should().BeFalse();
                commentItems[0].List.SortBy.Should().Be("rank");
                commentItems[0].List.SortHow.Should().Be("asc");
                commentItems[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.ItemCount.Should().Be(5);
                commentItems[0].List.CommentCount.Should().Be(1);
                commentItems[0].List.Likes.Should().Be(2);
                commentItems[0].List.Ids.Should().NotBeNull();
                commentItems[0].List.Ids.Trakt.Should().Be(55U);
                commentItems[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[0].List.User.Should().NotBeNull();
                commentItems[0].List.User.Username.Should().Be("sean");
                commentItems[0].List.User.IsPrivate.Should().BeFalse();
                commentItems[0].List.User.Name.Should().Be("Sean Rudford");
                commentItems[0].List.User.IsVIP.Should().BeTrue();
                commentItems[0].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[0].List.User.Ids.Should().NotBeNull();
                commentItems[0].List.User.Ids.Slug.Should().Be("sean");

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().NotBeNull();
                commentItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[1].Movie.Year.Should().Be(2015);
                commentItems[1].Movie.Ids.Should().NotBeNull();
                commentItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[1].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[1].Show.Should().NotBeNull();
                commentItems[1].Show.Title.Should().Be("Game of Thrones");
                commentItems[1].Show.Year.Should().Be(2011);
                commentItems[1].Show.Ids.Should().NotBeNull();
                commentItems[1].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[1].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[1].Season.Should().NotBeNull();
                commentItems[1].Season.Number.Should().Be(1);
                commentItems[1].Season.Ids.Should().NotBeNull();
                commentItems[1].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[1].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[1].Episode.Should().NotBeNull();
                commentItems[1].Episode.SeasonNumber.Should().Be(1);
                commentItems[1].Episode.Number.Should().Be(1);
                commentItems[1].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[1].Episode.Ids.Should().NotBeNull();
                commentItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[1].List.Should().NotBeNull();
                commentItems[1].List.Name.Should().Be("Star Wars in machete order");
                commentItems[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[1].List.DisplayNumbers.Should().BeTrue();
                commentItems[1].List.AllowComments.Should().BeFalse();
                commentItems[1].List.SortBy.Should().Be("rank");
                commentItems[1].List.SortHow.Should().Be("asc");
                commentItems[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.ItemCount.Should().Be(5);
                commentItems[1].List.CommentCount.Should().Be(1);
                commentItems[1].List.Likes.Should().Be(2);
                commentItems[1].List.Ids.Should().NotBeNull();
                commentItems[1].List.Ids.Trakt.Should().Be(55U);
                commentItems[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[1].List.User.Should().NotBeNull();
                commentItems[1].List.User.Username.Should().Be("sean");
                commentItems[1].List.User.IsPrivate.Should().BeFalse();
                commentItems[1].List.User.Name.Should().Be("Sean Rudford");
                commentItems[1].List.User.IsVIP.Should().BeTrue();
                commentItems[1].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[1].List.User.Ids.Should().NotBeNull();
                commentItems[1].List.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().NotBeNull();
                commentItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[0].Movie.Year.Should().Be(2015);
                commentItems[0].Movie.Ids.Should().NotBeNull();
                commentItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[0].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[0].Show.Should().NotBeNull();
                commentItems[0].Show.Title.Should().Be("Game of Thrones");
                commentItems[0].Show.Year.Should().Be(2011);
                commentItems[0].Show.Ids.Should().NotBeNull();
                commentItems[0].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[0].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[0].Season.Should().NotBeNull();
                commentItems[0].Season.Number.Should().Be(1);
                commentItems[0].Season.Ids.Should().NotBeNull();
                commentItems[0].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[0].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[0].Episode.Should().NotBeNull();
                commentItems[0].Episode.SeasonNumber.Should().Be(1);
                commentItems[0].Episode.Number.Should().Be(1);
                commentItems[0].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[0].Episode.Ids.Should().NotBeNull();
                commentItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[0].List.Should().NotBeNull();
                commentItems[0].List.Name.Should().Be("Star Wars in machete order");
                commentItems[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[0].List.DisplayNumbers.Should().BeTrue();
                commentItems[0].List.AllowComments.Should().BeFalse();
                commentItems[0].List.SortBy.Should().Be("rank");
                commentItems[0].List.SortHow.Should().Be("asc");
                commentItems[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.ItemCount.Should().Be(5);
                commentItems[0].List.CommentCount.Should().Be(1);
                commentItems[0].List.Likes.Should().Be(2);
                commentItems[0].List.Ids.Should().NotBeNull();
                commentItems[0].List.Ids.Trakt.Should().Be(55U);
                commentItems[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[0].List.User.Should().NotBeNull();
                commentItems[0].List.User.Username.Should().Be("sean");
                commentItems[0].List.User.IsPrivate.Should().BeFalse();
                commentItems[0].List.User.Name.Should().Be("Sean Rudford");
                commentItems[0].List.User.IsVIP.Should().BeTrue();
                commentItems[0].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[0].List.User.Ids.Should().NotBeNull();
                commentItems[0].List.User.Ids.Slug.Should().Be("sean");

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().NotBeNull();
                commentItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[1].Movie.Year.Should().Be(2015);
                commentItems[1].Movie.Ids.Should().NotBeNull();
                commentItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[1].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[1].Show.Should().BeNull();
                commentItems[1].Season.Should().BeNull();
                commentItems[1].Episode.Should().BeNull();
                commentItems[1].List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().NotBeNull();
                commentItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[0].Movie.Year.Should().Be(2015);
                commentItems[0].Movie.Ids.Should().NotBeNull();
                commentItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[0].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[0].Show.Should().BeNull();
                commentItems[0].Season.Should().BeNull();
                commentItems[0].Episode.Should().BeNull();
                commentItems[0].List.Should().BeNull();

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().NotBeNull();
                commentItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[1].Movie.Year.Should().Be(2015);
                commentItems[1].Movie.Ids.Should().NotBeNull();
                commentItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[1].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[1].Show.Should().NotBeNull();
                commentItems[1].Show.Title.Should().Be("Game of Thrones");
                commentItems[1].Show.Year.Should().Be(2011);
                commentItems[1].Show.Ids.Should().NotBeNull();
                commentItems[1].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[1].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[1].Season.Should().NotBeNull();
                commentItems[1].Season.Number.Should().Be(1);
                commentItems[1].Season.Ids.Should().NotBeNull();
                commentItems[1].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[1].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[1].Episode.Should().NotBeNull();
                commentItems[1].Episode.SeasonNumber.Should().Be(1);
                commentItems[1].Episode.Number.Should().Be(1);
                commentItems[1].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[1].Episode.Ids.Should().NotBeNull();
                commentItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[1].List.Should().NotBeNull();
                commentItems[1].List.Name.Should().Be("Star Wars in machete order");
                commentItems[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[1].List.DisplayNumbers.Should().BeTrue();
                commentItems[1].List.AllowComments.Should().BeFalse();
                commentItems[1].List.SortBy.Should().Be("rank");
                commentItems[1].List.SortHow.Should().Be("asc");
                commentItems[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.ItemCount.Should().Be(5);
                commentItems[1].List.CommentCount.Should().Be(1);
                commentItems[1].List.Likes.Should().Be(2);
                commentItems[1].List.Ids.Should().NotBeNull();
                commentItems[1].List.Ids.Trakt.Should().Be(55U);
                commentItems[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[1].List.User.Should().NotBeNull();
                commentItems[1].List.User.Username.Should().Be("sean");
                commentItems[1].List.User.IsPrivate.Should().BeFalse();
                commentItems[1].List.User.Name.Should().Be("Sean Rudford");
                commentItems[1].List.User.IsVIP.Should().BeTrue();
                commentItems[1].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[1].List.User.Ids.Should().NotBeNull();
                commentItems[1].List.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().BeNull();

                commentItems[0].Show.Should().NotBeNull();
                commentItems[0].Show.Title.Should().Be("Game of Thrones");
                commentItems[0].Show.Year.Should().Be(2011);
                commentItems[0].Show.Ids.Should().NotBeNull();
                commentItems[0].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[0].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[0].Season.Should().NotBeNull();
                commentItems[0].Season.Number.Should().Be(1);
                commentItems[0].Season.Ids.Should().NotBeNull();
                commentItems[0].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[0].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[0].Episode.Should().NotBeNull();
                commentItems[0].Episode.SeasonNumber.Should().Be(1);
                commentItems[0].Episode.Number.Should().Be(1);
                commentItems[0].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[0].Episode.Ids.Should().NotBeNull();
                commentItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[0].List.Should().NotBeNull();
                commentItems[0].List.Name.Should().Be("Star Wars in machete order");
                commentItems[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[0].List.DisplayNumbers.Should().BeTrue();
                commentItems[0].List.AllowComments.Should().BeFalse();
                commentItems[0].List.SortBy.Should().Be("rank");
                commentItems[0].List.SortHow.Should().Be("asc");
                commentItems[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.ItemCount.Should().Be(5);
                commentItems[0].List.CommentCount.Should().Be(1);
                commentItems[0].List.Likes.Should().Be(2);
                commentItems[0].List.Ids.Should().NotBeNull();
                commentItems[0].List.Ids.Trakt.Should().Be(55U);
                commentItems[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[0].List.User.Should().NotBeNull();
                commentItems[0].List.User.Username.Should().Be("sean");
                commentItems[0].List.User.IsPrivate.Should().BeFalse();
                commentItems[0].List.User.Name.Should().Be("Sean Rudford");
                commentItems[0].List.User.IsVIP.Should().BeTrue();
                commentItems[0].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[0].List.User.Ids.Should().NotBeNull();
                commentItems[0].List.User.Ids.Slug.Should().Be("sean");

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().NotBeNull();
                commentItems[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[1].Movie.Year.Should().Be(2015);
                commentItems[1].Movie.Ids.Should().NotBeNull();
                commentItems[1].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[1].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[1].Show.Should().NotBeNull();
                commentItems[1].Show.Title.Should().Be("Game of Thrones");
                commentItems[1].Show.Year.Should().Be(2011);
                commentItems[1].Show.Ids.Should().NotBeNull();
                commentItems[1].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[1].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[1].Season.Should().NotBeNull();
                commentItems[1].Season.Number.Should().Be(1);
                commentItems[1].Season.Ids.Should().NotBeNull();
                commentItems[1].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[1].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[1].Episode.Should().NotBeNull();
                commentItems[1].Episode.SeasonNumber.Should().Be(1);
                commentItems[1].Episode.Number.Should().Be(1);
                commentItems[1].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[1].Episode.Ids.Should().NotBeNull();
                commentItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[1].List.Should().NotBeNull();
                commentItems[1].List.Name.Should().Be("Star Wars in machete order");
                commentItems[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[1].List.DisplayNumbers.Should().BeTrue();
                commentItems[1].List.AllowComments.Should().BeFalse();
                commentItems[1].List.SortBy.Should().Be("rank");
                commentItems[1].List.SortHow.Should().Be("asc");
                commentItems[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.ItemCount.Should().Be(5);
                commentItems[1].List.CommentCount.Should().Be(1);
                commentItems[1].List.Likes.Should().Be(2);
                commentItems[1].List.Ids.Should().NotBeNull();
                commentItems[1].List.Ids.Trakt.Should().Be(55U);
                commentItems[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[1].List.User.Should().NotBeNull();
                commentItems[1].List.User.Username.Should().Be("sean");
                commentItems[1].List.User.IsPrivate.Should().BeFalse();
                commentItems[1].List.User.Name.Should().Be("Sean Rudford");
                commentItems[1].List.User.IsVIP.Should().BeTrue();
                commentItems[1].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[1].List.User.Ids.Should().NotBeNull();
                commentItems[1].List.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().NotBeNull();
                commentItems[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                commentItems[0].Movie.Year.Should().Be(2015);
                commentItems[0].Movie.Ids.Should().NotBeNull();
                commentItems[0].Movie.Ids.Trakt.Should().Be(94024U);
                commentItems[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                commentItems[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                commentItems[0].Movie.Ids.Tmdb.Should().Be(140607U);

                commentItems[0].Show.Should().NotBeNull();
                commentItems[0].Show.Title.Should().Be("Game of Thrones");
                commentItems[0].Show.Year.Should().Be(2011);
                commentItems[0].Show.Ids.Should().NotBeNull();
                commentItems[0].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[0].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[0].Season.Should().NotBeNull();
                commentItems[0].Season.Number.Should().Be(1);
                commentItems[0].Season.Ids.Should().NotBeNull();
                commentItems[0].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[0].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[0].Episode.Should().NotBeNull();
                commentItems[0].Episode.SeasonNumber.Should().Be(1);
                commentItems[0].Episode.Number.Should().Be(1);
                commentItems[0].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[0].Episode.Ids.Should().NotBeNull();
                commentItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[0].List.Should().NotBeNull();
                commentItems[0].List.Name.Should().Be("Star Wars in machete order");
                commentItems[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[0].List.DisplayNumbers.Should().BeTrue();
                commentItems[0].List.AllowComments.Should().BeFalse();
                commentItems[0].List.SortBy.Should().Be("rank");
                commentItems[0].List.SortHow.Should().Be("asc");
                commentItems[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.ItemCount.Should().Be(5);
                commentItems[0].List.CommentCount.Should().Be(1);
                commentItems[0].List.Likes.Should().Be(2);
                commentItems[0].List.Ids.Should().NotBeNull();
                commentItems[0].List.Ids.Trakt.Should().Be(55U);
                commentItems[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[0].List.User.Should().NotBeNull();
                commentItems[0].List.User.Username.Should().Be("sean");
                commentItems[0].List.User.IsPrivate.Should().BeFalse();
                commentItems[0].List.User.Name.Should().Be("Sean Rudford");
                commentItems[0].List.User.IsVIP.Should().BeTrue();
                commentItems[0].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[0].List.User.Ids.Should().NotBeNull();
                commentItems[0].List.User.Ids.Slug.Should().Be("sean");

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().BeNull();

                commentItems[1].Show.Should().NotBeNull();
                commentItems[1].Show.Title.Should().Be("Game of Thrones");
                commentItems[1].Show.Year.Should().Be(2011);
                commentItems[1].Show.Ids.Should().NotBeNull();
                commentItems[1].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[1].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[1].Season.Should().NotBeNull();
                commentItems[1].Season.Number.Should().Be(1);
                commentItems[1].Season.Ids.Should().NotBeNull();
                commentItems[1].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[1].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[1].Episode.Should().NotBeNull();
                commentItems[1].Episode.SeasonNumber.Should().Be(1);
                commentItems[1].Episode.Number.Should().Be(1);
                commentItems[1].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[1].Episode.Ids.Should().NotBeNull();
                commentItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[1].List.Should().NotBeNull();
                commentItems[1].List.Name.Should().Be("Star Wars in machete order");
                commentItems[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[1].List.DisplayNumbers.Should().BeTrue();
                commentItems[1].List.AllowComments.Should().BeFalse();
                commentItems[1].List.SortBy.Should().Be("rank");
                commentItems[1].List.SortHow.Should().Be("asc");
                commentItems[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.ItemCount.Should().Be(5);
                commentItems[1].List.CommentCount.Should().Be(1);
                commentItems[1].List.Likes.Should().Be(2);
                commentItems[1].List.Ids.Should().NotBeNull();
                commentItems[1].List.Ids.Trakt.Should().Be(55U);
                commentItems[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[1].List.User.Should().NotBeNull();
                commentItems[1].List.User.Username.Should().Be("sean");
                commentItems[1].List.User.IsPrivate.Should().BeFalse();
                commentItems[1].List.User.Name.Should().Be("Sean Rudford");
                commentItems[1].List.User.IsVIP.Should().BeTrue();
                commentItems[1].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[1].List.User.Ids.Should().NotBeNull();
                commentItems[1].List.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);

                traktCommentItems.Should().NotBeNull();
                ITraktCommentItem[] commentItems = traktCommentItems.ToArray();

                commentItems[0].Should().NotBeNull();
                commentItems[0].Type.Should().Be(TraktObjectType.Movie);

                commentItems[0].Movie.Should().BeNull();

                commentItems[0].Show.Should().NotBeNull();
                commentItems[0].Show.Title.Should().Be("Game of Thrones");
                commentItems[0].Show.Year.Should().Be(2011);
                commentItems[0].Show.Ids.Should().NotBeNull();
                commentItems[0].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[0].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[0].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[0].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[0].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[0].Season.Should().NotBeNull();
                commentItems[0].Season.Number.Should().Be(1);
                commentItems[0].Season.Ids.Should().NotBeNull();
                commentItems[0].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[0].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[0].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[0].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[0].Episode.Should().NotBeNull();
                commentItems[0].Episode.SeasonNumber.Should().Be(1);
                commentItems[0].Episode.Number.Should().Be(1);
                commentItems[0].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[0].Episode.Ids.Should().NotBeNull();
                commentItems[0].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[0].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[0].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[0].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[0].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[0].List.Should().NotBeNull();
                commentItems[0].List.Name.Should().Be("Star Wars in machete order");
                commentItems[0].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[0].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[0].List.DisplayNumbers.Should().BeTrue();
                commentItems[0].List.AllowComments.Should().BeFalse();
                commentItems[0].List.SortBy.Should().Be("rank");
                commentItems[0].List.SortHow.Should().Be("asc");
                commentItems[0].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[0].List.ItemCount.Should().Be(5);
                commentItems[0].List.CommentCount.Should().Be(1);
                commentItems[0].List.Likes.Should().Be(2);
                commentItems[0].List.Ids.Should().NotBeNull();
                commentItems[0].List.Ids.Trakt.Should().Be(55U);
                commentItems[0].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[0].List.User.Should().NotBeNull();
                commentItems[0].List.User.Username.Should().Be("sean");
                commentItems[0].List.User.IsPrivate.Should().BeFalse();
                commentItems[0].List.User.Name.Should().Be("Sean Rudford");
                commentItems[0].List.User.IsVIP.Should().BeTrue();
                commentItems[0].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[0].List.User.Ids.Should().NotBeNull();
                commentItems[0].List.User.Ids.Slug.Should().Be("sean");

                commentItems[1].Should().NotBeNull();
                commentItems[1].Type.Should().Be(TraktObjectType.Movie);

                commentItems[1].Movie.Should().BeNull();

                commentItems[1].Show.Should().NotBeNull();
                commentItems[1].Show.Title.Should().Be("Game of Thrones");
                commentItems[1].Show.Year.Should().Be(2011);
                commentItems[1].Show.Ids.Should().NotBeNull();
                commentItems[1].Show.Ids.Trakt.Should().Be(1390U);
                commentItems[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                commentItems[1].Show.Ids.Tvdb.Should().Be(121361U);
                commentItems[1].Show.Ids.Imdb.Should().Be("tt0944947");
                commentItems[1].Show.Ids.Tmdb.Should().Be(1399U);
                commentItems[1].Show.Ids.TvRage.Should().Be(24493U);

                commentItems[1].Season.Should().NotBeNull();
                commentItems[1].Season.Number.Should().Be(1);
                commentItems[1].Season.Ids.Should().NotBeNull();
                commentItems[1].Season.Ids.Trakt.Should().Be(61430U);
                commentItems[1].Season.Ids.Tvdb.Should().Be(279121U);
                commentItems[1].Season.Ids.Tmdb.Should().Be(60523U);
                commentItems[1].Season.Ids.TvRage.Should().Be(36939U);

                commentItems[1].Episode.Should().NotBeNull();
                commentItems[1].Episode.SeasonNumber.Should().Be(1);
                commentItems[1].Episode.Number.Should().Be(1);
                commentItems[1].Episode.Title.Should().Be("Winter Is Coming");
                commentItems[1].Episode.Ids.Should().NotBeNull();
                commentItems[1].Episode.Ids.Trakt.Should().Be(73640U);
                commentItems[1].Episode.Ids.Tvdb.Should().Be(3254641U);
                commentItems[1].Episode.Ids.Imdb.Should().Be("tt1480055");
                commentItems[1].Episode.Ids.Tmdb.Should().Be(63056U);
                commentItems[1].Episode.Ids.TvRage.Should().Be(1065008299U);

                commentItems[1].List.Should().NotBeNull();
                commentItems[1].List.Name.Should().Be("Star Wars in machete order");
                commentItems[1].List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
                commentItems[1].List.Privacy.Should().Be(TraktListPrivacy.Public);
                commentItems[1].List.DisplayNumbers.Should().BeTrue();
                commentItems[1].List.AllowComments.Should().BeFalse();
                commentItems[1].List.SortBy.Should().Be("rank");
                commentItems[1].List.SortHow.Should().Be("asc");
                commentItems[1].List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
                commentItems[1].List.ItemCount.Should().Be(5);
                commentItems[1].List.CommentCount.Should().Be(1);
                commentItems[1].List.Likes.Should().Be(2);
                commentItems[1].List.Ids.Should().NotBeNull();
                commentItems[1].List.Ids.Trakt.Should().Be(55U);
                commentItems[1].List.Ids.Slug.Should().Be("star-wars-in-machete-order");
                commentItems[1].List.User.Should().NotBeNull();
                commentItems[1].List.User.Username.Should().Be("sean");
                commentItems[1].List.User.IsPrivate.Should().BeFalse();
                commentItems[1].List.User.Name.Should().Be("Sean Rudford");
                commentItems[1].List.User.IsVIP.Should().BeTrue();
                commentItems[1].List.User.IsVIP_EP.Should().BeFalse();
                commentItems[1].List.User.Ids.Should().NotBeNull();
                commentItems[1].List.User.Ids.Slug.Should().Be("sean");
            }
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();
            Func<Task<IList<ITraktCommentItem>>> traktCommentItems = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktCommentItems.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentItemArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCommentItem>();

            using (var stream = string.Empty.ToStream())
            {
                IList<ITraktCommentItem> traktCommentItems = await jsonReader.ReadArrayAsync(stream);
                traktCommentItems.Should().BeNull();
            }
        }
    }
}
