namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonLists()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists",
                                                                SEASON_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithType()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}",
                                                                SEASON_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithSortOrderAndWithoutType()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists",
                                                                SEASON_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, sortOrder).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists?page={page}",
                                                                SEASON_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists?limit={limit}",
                                                                SEASON_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithPageAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists?page={page}&limit={limit}",
                SEASON_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndSortOrder()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}",
                SEASON_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?page={page}",
                SEASON_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?limit={limit}",
                SEASON_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndPageAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?page={page}&limit={limit}",
                SEASON_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndSortOrderAndPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                SEASON_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsWithTypeAndSortOrderAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                SEASON_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsComplete()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}" +
                $"?page={page}&limit={limit}",
                SEASON_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void Test_TraktSeasonsModule_GetSeasonListsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr);
            act.Should().Throw<TraktSeasonNotFoundException>();

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

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonListsArgumentsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists", SEASON_LISTS_JSON);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(null, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(string.Empty, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync("show id", seasonNr);
            act.Should().Throw<ArgumentException>();
        }
    }
}
