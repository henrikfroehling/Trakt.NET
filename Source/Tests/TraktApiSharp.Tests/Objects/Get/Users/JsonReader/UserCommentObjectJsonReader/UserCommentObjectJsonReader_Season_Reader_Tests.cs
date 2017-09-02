namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
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
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_2()
        {
            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktJsonReader = new UserCommentObjectJsonReader();

                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
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
                traktUserComment.Season.Should().BeNull();

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Season.Should().BeNull();

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktUserComment.Season.Should().BeNull();

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().BeNull();
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Season.Should().NotBeNull();
                traktUserComment.Season.Number.Should().Be(1);
                traktUserComment.Season.Title.Should().BeNullOrEmpty();
                traktUserComment.Season.Ids.Should().NotBeNull();
                traktUserComment.Season.Ids.Trakt.Should().Be(61430U);
                traktUserComment.Season.Ids.Tvdb.Should().Be(279121U);
                traktUserComment.Season.Ids.Tmdb.Should().Be(60523U);
                traktUserComment.Season.Ids.TvRage.Should().Be(36939U);

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Season);
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
                traktUserComment.Season.Should().BeNull();

                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserCommentObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserComment = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().BeNull();
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }
    }
}
