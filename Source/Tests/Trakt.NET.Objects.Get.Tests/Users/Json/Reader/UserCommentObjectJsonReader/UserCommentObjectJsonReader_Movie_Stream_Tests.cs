namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_COMPLETE.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
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
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

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
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
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
                traktUserComment.Movie.Should().BeNull();

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Movie.Should().BeNull();

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

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
                traktUserComment.Movie.Should().BeNull();

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().BeNull();
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_1.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

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
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_2.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Movie.Should().NotBeNull();
                traktUserComment.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserComment.Movie.Year.Should().Be(2015);
                traktUserComment.Movie.Ids.Should().NotBeNull();
                traktUserComment.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserComment.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserComment.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserComment.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_3.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().Be(TraktObjectType.Movie);
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
                traktUserComment.Movie.Should().BeNull();

                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_4.ToStream())
            {
                var traktUserComment = await jsonReader.ReadObjectAsync(stream);

                traktUserComment.Should().NotBeNull();
                traktUserComment.Type.Should().BeNull();
                traktUserComment.Comment.Should().BeNull();
                traktUserComment.Movie.Should().BeNull();
                traktUserComment.Show.Should().BeNull();
                traktUserComment.Season.Should().BeNull();
                traktUserComment.Episode.Should().BeNull();
                traktUserComment.List.Should().BeNull();
            }
        }
    }
}
