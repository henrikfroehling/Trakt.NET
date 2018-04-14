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
        public void Test_TraktMoviesModule_GetMostWatchedMovies()
        {
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched", MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync().Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesFiltered()
        {
            const int itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?{filter}", MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriod()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}",
                                                                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter}",
                                                                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfo()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo}",
                                                                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo}&{filter}",
                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}", MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&{filter}",
                                                                MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}", MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}&{filter}",
                                                                MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndExtendedOption()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?extended={extendedInfo}",
                                                                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo}&{filter}",
                MOST_WATCHED_MOVIES, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndPage()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}",
                                                                MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndPageFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter}&page={page}",
                                                                MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}",
                                                                MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}&{filter}",
                                                                MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo}&page={page}",
                                                                MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo}&page={page}&{filter}",
                MOST_WATCHED_MOVIES, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo}&limit={limit}",
                                                                MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo}&limit={limit}&{filter}",
                MOST_WATCHED_MOVIES, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&limit={limit}",
                                                                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?page={page}&limit={limit}&{filter}",
                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo}&page={page}&limit={limit}",
                                                                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo}&page={page}&{filter}&limit={limit}",
                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndPageAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}&limit={limit}",
                                                                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?page={page}&limit={limit}&{filter}",
                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesComplete()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesCompleteFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_WATCHED_MOVIES, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostWatchedMoviesExceptions()
        {
            const string uri = "movies/watched";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync();
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
