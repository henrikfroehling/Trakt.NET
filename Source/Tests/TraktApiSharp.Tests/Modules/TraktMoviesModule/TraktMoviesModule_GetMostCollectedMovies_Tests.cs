namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMovies()
        {
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected", MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesFiltered()
        {
            const int itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriod()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfo()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo}&{filter}",
                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}", MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}", MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}&{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndExtendedOption()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?extended={extendedInfo}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?{filter}&extended={extendedInfo}",
                MOST_COLLECTED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndPage()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndPageFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}&{filter}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo}&page={page}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo}&{filter}&page={page}",
                MOST_COLLECTED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo}&limit={limit}",
                                                                MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo}&{filter}&limit={limit}",
                MOST_COLLECTED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&limit={limit}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?page={page}&limit={limit}&{filter}",
                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo}&page={page}&limit={limit}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndPageAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&limit={limit}",
                                                                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?page={page}&{filter}&limit={limit}",
                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesComplete()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesCompleteFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_COLLECTED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMostCollectedMoviesExceptions()
        {
            const string uri = "movies/collected";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync();
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
