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
        public void Test_TraktShowsModule_GetMostPlayedShows()
        {
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played", MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync().Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsFiltered()
        {
            const int itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriod()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfo()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo}&{filter}",
                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}", MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?limit={limit}", MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?limit={limit}&{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndExtendedOption()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?extended={extendedInfo}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndExtendedOptionFiltered()
        {
            const int itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo}&{filter}",
                MOST_PLAYED_SHOWS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, filter).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?page={page}",
                                                                MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?{filter}&page={page}",
                                                                MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?limit={limit}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?limit={limit}&{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo}&page={page}",
                                                                MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo}&{filter}&page={page}",
                MOST_PLAYED_SHOWS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo}&limit={limit}",
                                                                MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo}&limit={limit}&{filter}",
                MOST_PLAYED_SHOWS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&limit={limit}",
                                                                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&limit={limit}&{filter}",
                                                                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo}&page={page}&limit={limit}",
                                                                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithExtendedInfoAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndPageAndLimit()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?page={page}&limit={limit}",
                                                                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsWithPeriodAndPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?page={page}&{filter}&limit={limit}",
                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsComplete()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsCompleteFiltered()
        {
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                MOST_PLAYED_SHOWS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void Test_TraktShowsModule_GetMostPlayedShowsExceptions()
        {
            const string uri = "shows/played";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync();
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
