﻿namespace TraktNet.Modules.Tests.TraktListsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private const string GET_TRENDING_LISTS_URI = "lists/trending";

        [Fact]
        public async Task Test_TraktListsModule_GetTrendingLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, LISTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Lists.GetTrendingListsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetTrendingLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_TRENDING_LISTS_URI}?page={PAGE}",
                                                           LISTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetTrendingListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetTrendingLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_TRENDING_LISTS_URI}?limit={LIMIT}",
                                                           LISTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetTrendingListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetTrendingLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_TRENDING_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           LISTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Lists.GetTrendingListsAsync(pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktListsModule_GetTrendingLists_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_LISTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Lists.GetTrendingListsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
