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
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeCommments()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments",
                                                                EPISODE_COMMENTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithSortOrder()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}",
                                                                EPISODE_COMMENTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}",
                                                                EPISODE_COMMENTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithSortOrderAndPage()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?page={page}",
                                                                EPISODE_COMMENTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?limit={limit}",
                                                                EPISODE_COMMENTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithSortOrderAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?limit={limit}",
                                                                EPISODE_COMMENTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsWithPageAndLimit()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 20;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}&limit={limit}",
                                                                EPISODE_COMMENTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsComplete()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;
            const int itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint page = 2;
            const uint limit = 20;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                EPISODE_COMMENTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, pagedParameters).Result;

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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr);
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
        public void Test_TraktEpisodesModule_GetEpisodeCommmentsArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments",
                                                                EPISODE_COMMENTS_JSON);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(null, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(string.Empty, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync("show id", seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
