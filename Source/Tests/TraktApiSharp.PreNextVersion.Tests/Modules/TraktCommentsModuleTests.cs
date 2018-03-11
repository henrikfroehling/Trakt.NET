namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;
    using TraktApiSharp.Objects.Post.Comments.Implementations;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Utils;

    [TestClass]
    public class TraktCommentsModuleTests
    {
        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetSingleComment

        [TestMethod]
        public void TestTraktCommentsModuleGetComment()
        {
            var comment = TestUtility.ReadFileContents(@"Objects\Basic\Comment.json");
            comment.Should().NotBeNullOrEmpty();

            var commentId = 76957U;

            TestUtility.SetupMockResponseWithoutOAuth($"comments/{commentId}", comment);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(commentId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(76957U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            responseValue.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.UserRating.Should().Be(7.3f);
            responseValue.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentExceptions()
        {
            var commentId = 76957U;
            var uri = $"comments/{commentId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(commentId);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentArgumentExceptions()
        {
            var comment = TestUtility.ReadFileContents(@"Objects\Basic\Comment.json");
            comment.Should().NotBeNullOrEmpty();

            var commentId = 76957U;

            TestUtility.SetupMockResponseWithoutOAuth($"comments/{commentId}", comment);

            Func<Task<TraktResponse<ITraktComment>>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetMultipleComments

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktComment>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(new uint[] { 0 });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(new uint[] { });
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetMutlipleCommentsAsync(null);
            act.Should().NotThrow();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostMovieComment

        [TestMethod]
        public void TestTraktCommentsModulePostMovieComment()
        {
            var movieCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            movieCommentPostResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var comment = "one two three four five";

            var movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, movieCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentWithSpoiler()
        {
            var movieCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            movieCommentPostResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var comment = "one two three four five";
            var spoiler = false;

            var movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, movieCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentWithSharing()
        {
            var movieCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            movieCommentPostResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";

            var movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = comment,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, movieCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment, null, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentComplete()
        {
            var movieCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            movieCommentPostResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";
            var spoiler = false;

            var movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, movieCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment, spoiler, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentExceptions()
        {
            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var comment = "one two three four five";

            var uri = "comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentArgumentExceptions()
        {
            var movieCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            movieCommentPostResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = (ITraktMovieIds)new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            var comment = "one two three four five";

            var movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, movieCommentPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(null, comment);

            act.Should().Throw<ArgumentNullException>();

            movie.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 123;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 12345;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentNullException>();

            movie.Ids = (ITraktMovieIds)new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentException>();

            movie.Ids = (ITraktMovieIds)new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostShowComment

        [TestMethod]
        public void TestTraktCommentsModulePostShowComment()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var comment = "one two three four five";

            var showCommentPost = new TraktShowCommentPost
            {
                Show = show,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(showCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, showCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSpoiler()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var comment = "one two three four five";
            var spoiler = false;

            var showCommentPost = new TraktShowCommentPost
            {
                Show = show,
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(showCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, showCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSharing()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";

            var showCommentPost = new TraktShowCommentPost
            {
                Show = show,
                Comment = comment,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(showCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, showCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment, null, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentComplete()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";
            var spoiler = false;

            var showCommentPost = new TraktShowCommentPost
            {
                Show = show,
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(showCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, showCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment, spoiler, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentExceptions()
        {
            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var comment = "one two three four five";

            var uri = "comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentArgumentExceptions()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = (ITraktShowIds)new TraktShowIds
                {
                    Trakt = 1388,
                    Slug = "breaking bad",
                    Tvdb = 81189,
                    Imdb = "tt0903747",
                    Tmdb = 1396,
                    TvRage = 18164
                }
            };

            var comment = "one two three four five";

            var showCommentPost = new TraktShowCommentPost
            {
                Show = show,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(showCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, showCommentPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(null, comment);

            act.Should().Throw<ArgumentNullException>();

            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.Should().Throw<ArgumentException>();

            show.Title = "Breaking Bad";
            show.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.Should().Throw<ArgumentNullException>();

            show.Ids = (ITraktShowIds)new TraktShowIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.Should().Throw<ArgumentException>();

            show.Ids = (ITraktShowIds)new TraktShowIds
            {
                Trakt = 1388,
                Slug = "breaking bad",
                Tvdb = 81189,
                Imdb = "tt0903747",
                Tmdb = 1396,
                TvRage = 18164
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostSeasonComment

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonComment()
        {
            var seasonCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            seasonCommentPostResponse.Should().NotBeNullOrEmpty();

            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var comment = "one two three four five";

            var seasonCommentPost = new TraktSeasonCommentPost
            {
                Season = season,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(seasonCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, seasonCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentWithSpoiler()
        {
            var seasonCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            seasonCommentPostResponse.Should().NotBeNullOrEmpty();

            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var comment = "one two three four five";
            var spoiler = false;

            var seasonCommentPost = new TraktSeasonCommentPost
            {
                Season = season,
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(seasonCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, seasonCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentWithSharing()
        {
            var seasonCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            seasonCommentPostResponse.Should().NotBeNullOrEmpty();

            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";

            var seasonCommentPost = new TraktSeasonCommentPost
            {
                Season = season,
                Comment = comment,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(seasonCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, seasonCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment, null, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentComplete()
        {
            var seasonCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            seasonCommentPostResponse.Should().NotBeNullOrEmpty();

            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";
            var spoiler = false;

            var seasonCommentPost = new TraktSeasonCommentPost
            {
                Season = season,
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(seasonCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, seasonCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment, spoiler, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentExceptions()
        {
            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var comment = "one two three four five";

            var uri = "comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentArgumentExceptions()
        {
            var seasonCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            seasonCommentPostResponse.Should().NotBeNullOrEmpty();

            var season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3950,
                    Tvdb = 30272,
                    Tmdb = 3572
                }
            };

            var comment = "one two three four five";

            var seasonCommentPost = new TraktSeasonCommentPost
            {
                Season = season,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(seasonCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, seasonCommentPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(null, comment);

            act.Should().Throw<ArgumentNullException>();

            season.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment);
            act.Should().Throw<ArgumentNullException>();

            season.Ids = new TraktSeasonIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment);
            act.Should().Throw<ArgumentException>();

            season.Ids = new TraktSeasonIds
            {
                Trakt = 3950,
                Tvdb = 30272,
                Tmdb = 3572
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostSeasonCommentAsync(season, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostEpisodeComment

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeComment()
        {
            var episodeCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            episodeCommentPostResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var comment = "one two three four five";

            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Episode = episode,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(episodeCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, episodeCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentWithSpoiler()
        {
            var episodeCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            episodeCommentPostResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var comment = "one two three four five";
            var spoiler = false;

            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Episode = episode,
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(episodeCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, episodeCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentWithSharing()
        {
            var episodeCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            episodeCommentPostResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";

            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Episode = episode,
                Comment = comment,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, episodeCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment, null, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentComplete()
        {
            var episodeCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            episodeCommentPostResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";
            var spoiler = false;

            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Episode = episode,
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, episodeCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment, spoiler, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentExceptions()
        {
            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var comment = "one two three four five";

            var uri = "comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentArgumentExceptions()
        {
            var episodeCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            episodeCommentPostResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 73482,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var comment = "one two three four five";

            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Episode = episode,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(episodeCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, episodeCommentPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(null, comment);

            act.Should().Throw<ArgumentNullException>();

            episode.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment);
            act.Should().Throw<ArgumentException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 73482,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostEpisodeCommentAsync(episode, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostListComment

        [TestMethod]
        public void TestTraktCommentsModulePostListComment()
        {
            var listCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            listCommentPostResponse.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var comment = "one two three four five";

            var listCommentPost = new TraktListCommentPost
            {
                List = list,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(listCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, listCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentWithSpoiler()
        {
            var listCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            listCommentPostResponse.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var comment = "one two three four five";
            var spoiler = false;

            var listCommentPost = new TraktListCommentPost
            {
                List = list,
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(listCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, listCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentWithSharing()
        {
            var listCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            listCommentPostResponse.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";

            var listCommentPost = new TraktListCommentPost
            {
                List = list,
                Comment = comment,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(listCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, listCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment, null, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentComplete()
        {
            var listCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            listCommentPostResponse.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var comment = "one two three four five";
            var spoiler = false;

            var listCommentPost = new TraktListCommentPost
            {
                List = list,
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(listCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, listCommentPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment, spoiler, sharing).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentExceptions()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var comment = "one two three four five";

            var uri = "comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentArgumentExceptions()
        {
            var listCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            listCommentPostResponse.Should().NotBeNullOrEmpty();

            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = 2228577,
                    Slug = "oscars-2016"
                }
            };

            var comment = "one two three four five";

            var listCommentPost = new TraktListCommentPost
            {
                List = list,
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(listCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("comments", postJson, listCommentPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(null, comment);

            act.Should().Throw<ArgumentNullException>();

            list.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment);
            act.Should().Throw<ArgumentNullException>();

            list.Ids = new TraktListIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment);
            act.Should().Throw<ArgumentException>();

            list.Ids = new TraktListIds
            {
                Trakt = 2228577,
                Slug = "oscars-2016"
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostListCommentAsync(list, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UpdateComment

        [TestMethod]
        public void TestTraktCommentsModuleUpdateComment()
        {
            var commentUpdatePostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentUpdatePostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five update";

            var commentUpdatePost = new TraktCommentUpdatePost
            {
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(commentUpdatePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}", postJson, commentUpdatePostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentWithSpoiler()
        {
            var commentUpdatePostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentUpdatePostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five update";
            var spoiler = false;

            var commentUpdatePost = new TraktCommentUpdatePost
            {
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(commentUpdatePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}", postJson, commentUpdatePostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentExceptions()
        {
            var commentId = 190U;
            var comment = "one two three four five update";

            var commentUpdatePost = new TraktCommentUpdatePost
            {
                Comment = comment
            };

            var uri = $"comments/{commentId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentArgumentExceptions()
        {
            var commentUpdatePostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentUpdatePostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five update";

            var commentUpdatePost = new TraktCommentUpdatePost
            {
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(commentUpdatePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}", postJson, commentUpdatePostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(0, comment);

            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UpdateCommentAsync(commentId, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostCommentReply

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReply()
        {
            var commentReplyPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentReplyPostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five reply";

            var commentReplyPost = new TraktCommentReplyPost
            {
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/replies", postJson, commentReplyPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, comment).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyWithSpoiler()
        {
            var commentReplyPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentReplyPostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five reply";
            var spoiler = false;

            var commentReplyPost = new TraktCommentReplyPost
            {
                Comment = comment,
                Spoiler = spoiler
            };

            var postJson = TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/replies", postJson, commentReplyPostResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, comment, spoiler).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(190U);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyExceptions()
        {
            var commentId = 190U;
            var comment = "one two three four five reply";

            var commentReplyPost = new TraktCommentReplyPost
            {
                Comment = comment
            };

            var uri = $"comments/{commentId}/replies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, comment);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyArgumentExceptions()
        {
            var commentReplyPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            commentReplyPostResponse.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var comment = "one two three four five reply";

            var commentReplyPost = new TraktCommentReplyPost
            {
                Comment = comment
            };

            var postJson = TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/replies", postJson, commentReplyPostResponse);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(0, comment);

            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, string.Empty);
            act.Should().Throw<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostCommentReplyAsync(commentId, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DeleteComment

        [TestMethod]
        public void TestTraktCommentsModuleDeleteComment()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}", HttpStatusCode.NoContent);
            var response = TestUtility.MOCK_TEST_CLIENT.Comments.DeleteCommentAsync(commentId).Result;
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModuleDeleteCommentExceptions()
        {
            var commentId = 190U;

            var uri = $"comments/{commentId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.DeleteCommentAsync(commentId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleDeleteCommentArgumentExceptions()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}", HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.DeleteCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region LikeComment

        [TestMethod]
        public void TestTraktCommentsModuleLikeComment()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/like", HttpStatusCode.NoContent);
            var response = TestUtility.MOCK_TEST_CLIENT.Comments.LikeCommentAsync(commentId).Result;
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModuleLikeCommentExceptions()
        {
            var commentId = 190U;

            var uri = $"comments/{commentId}/like";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.LikeCommentAsync(commentId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleLikeCommentArgumentExceptions()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/like", HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.LikeCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnlikeComment

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeComment()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/like", HttpStatusCode.NoContent);
            var response = TestUtility.MOCK_TEST_CLIENT.Comments.UnlikeCommentAsync(commentId).Result;
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeCommentExceptions()
        {
            var commentId = 190U;

            var uri = $"comments/{commentId}/like";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UnlikeCommentAsync(commentId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeCommentArgumentExceptions()
        {
            var commentId = 190U;

            TestUtility.SetupMockResponseWithOAuth($"comments/{commentId}/like", HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.UnlikeCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCommentReplies

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentReplies()
        {
            var commentReplies = TestUtility.ReadFileContents(@"Objects\Basic\CommentReplies.json");
            commentReplies.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"comments/{commentId}/replies",
                                                                commentReplies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(commentId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesWithPage()
        {
            var commentReplies = TestUtility.ReadFileContents(@"Objects\Basic\CommentReplies.json");
            commentReplies.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"comments/{commentId}/replies?page={page}",
                                                                commentReplies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(commentId, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesWithLimit()
        {
            var commentReplies = TestUtility.ReadFileContents(@"Objects\Basic\CommentReplies.json");
            commentReplies.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"comments/{commentId}/replies?limit={limit}",
                                                                commentReplies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(commentId, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesComplete()
        {
            var commentReplies = TestUtility.ReadFileContents(@"Objects\Basic\CommentReplies.json");
            commentReplies.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"comments/{commentId}/replies?page={page}&limit={limit}",
                                                                commentReplies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(commentId, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesExceptions()
        {
            var commentId = 190U;
            var uri = $"comments/{commentId}/replies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(commentId);
            act.Should().Throw<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesArgumentExceptions()
        {
            var commentReplies = TestUtility.ReadFileContents(@"Objects\Basic\CommentReplies.json");
            commentReplies.Should().NotBeNullOrEmpty();

            var commentId = 190U;
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"comments/{commentId}/replies",
                                                                commentReplies, 1, 10, 1, itemCount);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentRepliesAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
