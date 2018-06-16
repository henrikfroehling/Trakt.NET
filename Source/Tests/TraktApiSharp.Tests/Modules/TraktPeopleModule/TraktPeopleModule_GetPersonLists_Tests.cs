namespace TraktApiSharp.Tests.Modules.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        private readonly string GET_PERSON_LISTS_URI = $"people/{PERSON_ID}/lists";

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI,
                                                           PERSON_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}",
                                                           PERSON_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_SortOrder_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI,
                                                           PERSON_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, null, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}?page={PAGE}",
                                                           PERSON_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}?limit={LIMIT}",
                                                           PERSON_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           PERSON_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}",
                                                           PERSON_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}",
                                                           PERSON_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}?limit={LIMIT}",
                                                           PERSON_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                                                           PERSON_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}",
                                                           PERSON_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_With_Type_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           PERSON_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           PERSON_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.People.GetPersonListsAsync(PERSON_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktPersonNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonLists_ArgumentsExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_LISTS_URI,
                                                           PERSON_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.People.GetPersonListsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonListsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonListsAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
