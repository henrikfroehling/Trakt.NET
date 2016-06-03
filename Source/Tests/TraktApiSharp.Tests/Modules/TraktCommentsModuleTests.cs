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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentWithSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostMovieCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PostShowComment

        [TestMethod]
        public void TestTraktCommentsModulePostShowComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSpoiler()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentWithSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModulePostShowCommentArgumentExceptions()
        {
            Assert.Fail();
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
