namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktSearchModuleTests
    {
        [TestMethod]
        public void TestTraktSearchModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktSearchModule)).Should().BeTrue();
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

        #region SearchTextQuery

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQuery()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYear()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndYear()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SearchIdLookup

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookup()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
