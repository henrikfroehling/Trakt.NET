namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktRecommendationsModuleTests
    {
        [TestMethod]
        public void TestTraktRecommendationsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktRecommendationsModule)).Should().BeTrue();
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

        #region UserMovieRecommendations

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendations()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region HiderUserMovieRecommentation

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserMovieRecommendation()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserMovieRecommendationExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserMovieRecommendationArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserShowRecommendations

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserShowRecommendations()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserShowRecommendationsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserShowRecommendationsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserShowRecommendationsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserShowRecommendationsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region HiderUserShowRecommentation

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserShowRecommendation()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserShowRecommendationExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleHideUserShowRecommendationArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
