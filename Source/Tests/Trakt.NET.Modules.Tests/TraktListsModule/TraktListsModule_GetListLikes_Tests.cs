namespace TraktNet.Modules.Tests.TraktListsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string GET_LIST_LIKES_URI = $"lists/{LIST_ID}/likes";

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI,
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(TRAKT_LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{LIST_SLUG}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_List()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(list);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?extended={EXTENDED_INFO}",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}",
                LIST_LIKES_JSON, PAGE, 10, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                LIST_LIKES_JSON, PAGE, 10, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}&limit={LIMIT}",
                LIST_LIKES_JSON, PAGE, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                LIST_LIKES_JSON, PAGE, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIMIT}",
                LIST_LIKES_JSON, 2, LIMIT, 5, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIMIT}",
                LIST_LIKES_JSON, 2, LIMIT, 2, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 2, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 1, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIMIT}",
                LIST_LIKES_JSON, 2, LIMIT, 2, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_LIST_LIKES_URI}?page=1&limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 2, LIST_LIKES_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIMIT}",
                LIST_LIKES_JSON, 1, LIMIT, 2, LIST_LIKES_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Lists.GetListLikesAsync(LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_LIST_LIKES_URI}?page=2&limit={LIMIT}",
                LIST_LIKES_JSON, 2, LIMIT, 2, LIST_LIKES_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktListNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktListsModule_GetListLikes_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, statusCode);

            try
            {
                await client.Lists.GetListLikesAsync(LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListLikes_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI,
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_COUNT);

            Func<Task<TraktPagedResponse<ITraktListLike>>> act = () => client.Lists.GetListLikesAsync(default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListLikesAsync(default(ITraktList));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListLikesAsync(new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListLikesAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
