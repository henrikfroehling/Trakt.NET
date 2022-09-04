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
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string GET_LIST_URI = $"lists/{SINGLE_LIST_ID}";

        [Fact]
        public async Task Test_TraktListsModule_GetList()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_URI, SINGLE_LIST_JSON);

            TraktResponse<ITraktList> response = await client.Lists.GetListAsync(SINGLE_LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
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
        public async Task Test_TraktListsModule_GetList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_URI, statusCode);

            try
            {
                await client.Lists.GetListAsync(SINGLE_LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktListsModule_GetList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_URI, SINGLE_LIST_JSON);

            Func<Task<TraktResponse<ITraktList>>> act = () => client.Lists.GetListAsync(-1);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
