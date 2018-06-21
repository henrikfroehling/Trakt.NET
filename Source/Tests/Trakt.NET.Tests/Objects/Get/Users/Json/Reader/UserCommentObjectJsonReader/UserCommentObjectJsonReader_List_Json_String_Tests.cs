namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_COMPLETE);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_1);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().BeNull();
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_2);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().BeNull();
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_3);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().BeNull();

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_4);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().BeNull();
            traktUserComment.List.Should().BeNull();

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_5);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().BeNull();
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().BeNull();

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_6);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().BeNull();
            traktUserComment.Comment.Should().BeNull();
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_1);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().BeNull();
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_2);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().BeNull();
            traktUserComment.List.Should().NotBeNull();
            traktUserComment.List.Name.Should().Be("Star Wars in machete order");
            traktUserComment.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserComment.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserComment.List.DisplayNumbers.Should().BeTrue();
            traktUserComment.List.AllowComments.Should().BeFalse();
            traktUserComment.List.SortBy.Should().Be("rank");
            traktUserComment.List.SortHow.Should().Be("asc");
            traktUserComment.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserComment.List.ItemCount.Should().Be(5);
            traktUserComment.List.CommentCount.Should().Be(1);
            traktUserComment.List.Likes.Should().Be(2);
            traktUserComment.List.Ids.Should().NotBeNull();
            traktUserComment.List.Ids.Trakt.Should().Be(55);
            traktUserComment.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserComment.List.User.Should().NotBeNull();
            traktUserComment.List.User.Username.Should().Be("sean");
            traktUserComment.List.User.IsPrivate.Should().BeFalse();
            traktUserComment.List.User.Name.Should().Be("Sean Rudford");
            traktUserComment.List.User.IsVIP.Should().BeTrue();
            traktUserComment.List.User.IsVIP_EP.Should().BeFalse();
            traktUserComment.List.User.Ids.Should().NotBeNull();
            traktUserComment.List.User.Ids.Slug.Should().Be("sean");

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_3);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().Be(TraktObjectType.List);
            traktUserComment.Comment.Should().NotBeNull();
            traktUserComment.Comment.Id.Should().Be(76957U);
            traktUserComment.Comment.ParentId.Should().Be(1234U);
            traktUserComment.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktUserComment.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktUserComment.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktUserComment.Comment.Spoiler.Should().BeFalse();
            traktUserComment.Comment.Review.Should().BeFalse();
            traktUserComment.Comment.Replies.Should().Be(1);
            traktUserComment.Comment.Likes.Should().Be(2);
            traktUserComment.Comment.UserRating.Should().Be(7.3f);
            traktUserComment.Comment.User.Should().NotBeNull();
            traktUserComment.Comment.User.Username.Should().Be("sean");
            traktUserComment.Comment.User.IsPrivate.Should().BeFalse();
            traktUserComment.Comment.User.Name.Should().Be("Sean Rudford");
            traktUserComment.Comment.User.IsVIP.Should().BeTrue();
            traktUserComment.Comment.User.IsVIP_EP.Should().BeTrue();
            traktUserComment.Comment.User.Ids.Should().NotBeNull();
            traktUserComment.Comment.User.Ids.Slug.Should().Be("sean");
            traktUserComment.List.Should().BeNull();

            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_4);

            traktUserComment.Should().NotBeNull();
            traktUserComment.Type.Should().BeNull();
            traktUserComment.Comment.Should().BeNull();
            traktUserComment.List.Should().BeNull();
            traktUserComment.Movie.Should().BeNull();
            traktUserComment.Show.Should().BeNull();
            traktUserComment.Season.Should().BeNull();
            traktUserComment.Episode.Should().BeNull();
        }
    }
}
