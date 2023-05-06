namespace TraktNet.Modules.Tests.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.People;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        private const string GET_RECENTLY_UPDATED_PEOPLE_URI = "people/updates";

        private readonly DateTime TODAY = DateTime.UtcNow;

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_PEOPLE_URI,
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, 10, 1, UPDATED_PEOPLE_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, 10, 1, UPDATED_PEOPLE_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?extended={EXTENDED_INFO}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, 10, 1, UPDATED_PEOPLE_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?page={PAGE}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, 10, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, 10, 1, UPDATED_PEOPLE_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?page={PAGE}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, 10, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, 10, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_With_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_PEOPLE_JSON, PAGE, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 2, LIMIT, 5, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 2, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 1, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 2, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 1, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedPerson> response = await client.People.GetRecentlyUpdatedPeopleAsync(TODAY, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_RECENTLY_UPDATED_PEOPLE_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_PEOPLE_JSON, 2, LIMIT, 2, UPDATED_PEOPLE_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_PEOPLE_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_PEOPLE_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
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
        public async Task Test_TraktPeopleModule_GetRecentlyUpdatedPeople_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_PEOPLE_URI, statusCode);

            try
            {
                await client.People.GetRecentlyUpdatedPeopleAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
