namespace TraktNet.Modules.Tests.TraktCheckinsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Checkins")]
    public partial class TraktCheckinsModule_Tests
    {
        [Fact]
        public async Task Test_TraktCheckinsModule_DeleteAnyActiveCheckins()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Checkins.DeleteAnyActiveCheckinsAsync();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.NotFound);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.Conflict);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)412);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)422);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)429);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)503);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)504);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)520);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)521);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCheckinsModule_DeleteAnyActiveCheckins_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECKIN_URI, (HttpStatusCode)522);
            Func<Task<TraktNoContentResponse>> act = () => client.Checkins.DeleteAnyActiveCheckinsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
