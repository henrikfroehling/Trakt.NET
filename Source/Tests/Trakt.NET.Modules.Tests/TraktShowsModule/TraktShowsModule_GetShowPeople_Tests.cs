namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_PEOPLE_URI = $"shows/{SHOW_ID}/people";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowPeople()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, SHOW_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowPeople_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_PEOPLE_URI}?extended={EXTENDED_INFO}",
                SHOW_PEOPLE_JSON);

            TraktResponse<ITraktCastAndCrew> response = await client.Shows.GetShowPeopleAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowPeople_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_PEOPLE_URI, SHOW_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Shows.GetShowPeopleAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowPeopleAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowPeopleAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
