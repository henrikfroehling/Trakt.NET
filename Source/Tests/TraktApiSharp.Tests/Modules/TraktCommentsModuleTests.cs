namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
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

        #region GetComment

        [TestMethod]
        public void TestTraktCommentsModuleGetComment()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetComments

        [TestMethod]
        public void TestTraktCommentsModuleGetCommentsArgumentExceptions()
        {
            Assert.Fail();
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
