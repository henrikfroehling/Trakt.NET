namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Post.Comments;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using Utils;

    [TestClass]
    public class TraktCommentsModuleTests
    {
        [TestMethod]
        public void TestTraktCommentsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktCommentsModule)).Should().BeTrue();
        }

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

            var commentId = "76957";

            TestUtility.SetupMockResponseWithoutOAuth($"comments/{commentId}", comment);

            var response = TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(commentId).Result;

            response.Should().NotBeNull();
            response.Id.Should().Be(76957);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            response.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(1);
            response.Likes.Should().Be(2);
            response.UserRating.Should().Be(7.3f);
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentExceptions()
        {
            var commentId = "76957";
            var uri = $"comments/{commentId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktComment>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(commentId);
            act.ShouldThrow<TraktCommentNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentArgumentExceptions()
        {
            var comment = TestUtility.ReadFileContents(@"Objects\Basic\Comment.json");
            comment.Should().NotBeNullOrEmpty();

            var commentId = "76957";

            TestUtility.SetupMockResponseWithoutOAuth($"comments/{commentId}", comment);

            Func<Task<TraktComment>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetMultipleComments

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentsArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentsAsync(new string[] { null });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentsAsync(new string[] { string.Empty });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentsAsync(new string[] { });
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.GetCommentsAsync(null);
            act.ShouldNotThrow();
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
                Ids = new TraktMovieIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
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
                Ids = new TraktMovieIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
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
                Ids = new TraktMovieIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
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
                Ids = new TraktMovieIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentExceptions()
        {
            var movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
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

            Func<Task<TraktCommentPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
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
                Ids = new TraktMovieIds
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

            Func<Task<TraktCommentPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(null, comment);

            act.ShouldThrow<ArgumentNullException>();

            movie.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<ArgumentException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, string.Empty);
            act.ShouldThrow<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostMovieCommentAsync(movie, comment);
            act.ShouldThrow<ArgumentException>();
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
                Ids = new TraktShowIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSpoiler()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSharing()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentComplete()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
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
            response.Id.Should().Be(190);
            response.ParentId.Should().Be(0);
            response.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            response.Comment.Should().Be("Oh, I wasn't really listening.");
            response.Spoiler.Should().BeFalse();
            response.Review.Should().BeFalse();
            response.Replies.Should().Be(0);
            response.Likes.Should().Be(0);
            response.UserRating.Should().NotHaveValue();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Sharing.Medium.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentExceptions()
        {
            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
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

            Func<Task<TraktCommentPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentArgumentExceptions()
        {
            var showCommentPostResponse = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");
            showCommentPostResponse.Should().NotBeNullOrEmpty();

            var show = new TraktShow
            {
                Title = "Breaking Bad",
                Ids = new TraktShowIds
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

            Func<Task<TraktCommentPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(null, comment);

            act.ShouldThrow<ArgumentNullException>();

            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.ShouldThrow<ArgumentException>();

            show.Title = "Breaking Bad";
            show.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.ShouldThrow<ArgumentException>();

            show.Ids = new TraktShowIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.ShouldThrow<ArgumentException>();

            show.Ids = new TraktShowIds
            {
                Trakt = 1388,
                Slug = "breaking bad",
                Tvdb = 81189,
                Imdb = "tt0903747",
                Tmdb = 1396,
                TvRage = 18164
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, string.Empty);
            act.ShouldThrow<ArgumentException>();

            comment = "one two three four";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Comments.PostShowCommentAsync(show, comment);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostSeasonComment

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentWithSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostSeasonCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostEpisodeComment

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentWithSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostEpisodeCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostListComment

        [TestMethod]
        public void TestTraktCommentsModulePostListComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentWithSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostListCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UpdateComment

        [TestMethod]
        public void TestTraktCommentsModuleUpdateComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUpdateCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostCommentReply

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReply()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostCommentReplyArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DeleteComment

        [TestMethod]
        public void TestTraktCommentsModuleDeleteComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleDeleteCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleDeleteCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region LikeComment

        [TestMethod]
        public void TestTraktCommentsModuleLikeComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleLikeCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleLikeCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnlikeComment

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleUnlikeCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCommmentReply

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentReply()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentReplyExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentReplyArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCommentReplies

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentReplies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentRepliesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
