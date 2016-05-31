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
    using TraktApiSharp.Objects.Get.Recommendations;
    using TraktApiSharp.Requests;
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
            var movies = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\MovieRecommendations.json");
            movies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockPaginationResponseWithOAuth($"recommendations/movies", movies, 1, 10);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetUserMovieRecommendationsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().HaveValue().And.Be(1);
            response.Limit.Should().HaveValue().And.Be(10);
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsWithLimit()
        {
            var movies = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\MovieRecommendations.json");
            movies.Should().NotBeNullOrEmpty();

            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"recommendations/movies?limit={limit}", movies, 1, limit);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetUserMovieRecommendationsAsync(limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().HaveValue().And.Be(1);
            response.Limit.Should().HaveValue().And.Be(limit);
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsWithExtendedOption()
        {
            var movies = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\MovieRecommendations.json");
            movies.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"recommendations/movies?extended={extendedOption.ToString()}",
                                                             movies, 1, 10);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetUserMovieRecommendationsAsync(null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().HaveValue().And.Be(1);
            response.Limit.Should().HaveValue().And.Be(10);
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsComplete()
        {
            var movies = TestUtility.ReadFileContents(@"Objects\Get\Recommendations\MovieRecommendations.json");
            movies.Should().NotBeNullOrEmpty();

            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"recommendations/movies?extended={extendedOption.ToString()}&limit={limit}",
                movies, 1, limit);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetUserMovieRecommendationsAsync(limit, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().HaveValue().And.Be(1);
            response.Limit.Should().HaveValue().And.Be(limit);
        }

        [TestMethod]
        public void TestTraktRecommendationsModuleGetUserMovieRecommendationsExceptions()
        {
            var uri = $"recommendations/movies";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktMovieRecommendation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Recommendations.GetUserMovieRecommendationsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
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
