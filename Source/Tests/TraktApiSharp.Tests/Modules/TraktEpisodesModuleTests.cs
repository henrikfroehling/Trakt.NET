namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktEpisodesModuleTests
    {
        [TestMethod]
        public void TestTraktEpisodesModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktEpisodesModule)).Should().BeTrue();
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

        #region Episode

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeComments

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeRatings

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeStatistics

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeWatchingUsers

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
