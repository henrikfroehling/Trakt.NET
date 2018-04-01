namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
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

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists",
                                                                EPISODE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithType()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}",
                EPISODE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithSortOrderAndWithoutType()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists",
                EPISODE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, sortOrder).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?page={page}",
                EPISODE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?limit={limit}",
                EPISODE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithPageAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?page={page}&limit={limit}",
                EPISODE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndSortOrder()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}",
                EPISODE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      type, sortOrder).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?page={page}",
                EPISODE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?limit={limit}",
                EPISODE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndPageAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?page={page}&limit={limit}",
                EPISODE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndSortOrderAndPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                EPISODE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsWithTypeAndSortOrderAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                EPISODE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsComplete()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}" +
                $"?page={page}&limit={limit}",
                EPISODE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeListsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr);
            act.Should().Throw<TraktEpisodeNotFoundException>();

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
        public void Test_TraktEpisodesModule_GetEpisodeListsArgumentsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists", EPISODE_LISTS_JSON);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(null, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(string.Empty, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync("show id", seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
