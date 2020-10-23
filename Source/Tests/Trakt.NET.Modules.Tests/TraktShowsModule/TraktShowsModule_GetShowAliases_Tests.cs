namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_ALIASES_URI = $"shows/{SHOW_ID}/aliases";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowAliases()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_ALIASES_URI, SHOW_ALIASES_JSON);
            TraktListResponse<ITraktShowAlias> response = await client.Shows.GetShowAliasesAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(8);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktShowsModule_GetShowAliases_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_ALIASES_URI, statusCode);

            try
            {
                await client.Shows.GetShowAliasesAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowAliases_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_ALIASES_URI, SHOW_ALIASES_JSON);

            Func<Task<TraktListResponse<ITraktShowAlias>>> act = () => client.Shows.GetShowAliasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowAliasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowAliasesAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
