namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktPeopleModuleTests
    {
        [TestMethod]
        public void TestTraktPeopleModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktPeopleModule)).Should().BeTrue();
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

        #region SinglePerson

        [TestMethod]
        public void TestTraktPeopleModuleGetPerson()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultiplePerson

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PersonMovieCredits

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCredits()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PersonShowCredits

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCredits()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
