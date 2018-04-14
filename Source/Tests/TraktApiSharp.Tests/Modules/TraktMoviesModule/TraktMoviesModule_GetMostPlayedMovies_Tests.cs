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
        public void Test_TraktMoviesModule_GetMostPlayedMovies()
        {
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played", MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync().Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesFiltered()
        {
            const int itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?{filter}", MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriod()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfo()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo}&{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}", MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}", MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}&{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndExtendedOption()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?extended={extendedInfo}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo}&{filter}",
                MOST_PLAYED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, filter).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndPage()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}",
                                                                MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndPageFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter}&page={page}",
                                                                MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}&{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo}&page={page}",
                                                                MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo}&page={page}&{filter}",
                MOST_PLAYED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo}&limit={limit}",
                                                                MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo}&limit={limit}&{filter}",
                MOST_PLAYED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}",
                                                                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}&{filter}",
                                                                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo}&page={page}&limit={limit}",
                                                                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndPageAndLimit()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}&limit={limit}",
                                                                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?page={page}&limit={limit}&{filter}",
                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesComplete()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesCompleteFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_PLAYED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMostPlayedMoviesExceptions()
        {
            const string uri = "movies/played";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync();
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
