namespace TraktApiSharp.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows()
        {
            const int itemCount = 2;
            const int userCount = 300;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending", TRENDING_SHOWS_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?{filter}",
                                                                TRENDING_SHOWS_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfo()
        {
            const int itemCount = 2;
            const int userCount = 300;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo}",
                                                                TRENDING_SHOWS_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo}&{filter}",
                TRENDING_SHOWS_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithPage()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}", TRENDING_SHOWS_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithPageFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?{filter}&page={page}",
                                                                TRENDING_SHOWS_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo}&page={page}",
                                                                TRENDING_SHOWS_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo}&page={page}&{filter}",
                TRENDING_SHOWS_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?limit={limit}", TRENDING_SHOWS_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?limit={limit}&{filter}",
                                                                TRENDING_SHOWS_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo}&limit={limit}",
                                                                TRENDING_SHOWS_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo}&{filter}&limit={limit}",
                TRENDING_SHOWS_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithPageAndLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}&limit={limit}",
                                                                TRENDING_SHOWS_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}&limit={limit}&{filter}",
                                                                TRENDING_SHOWS_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsComplete()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo}&page={page}&limit={limit}",
                                                                TRENDING_SHOWS_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsCompleteFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                TRENDING_SHOWS_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShowsExceptions()
        {
            const string uri = "shows/trending";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

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
    }
}
