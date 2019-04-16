﻿namespace TraktNet.Modules.Tests.TraktCertificationsModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Certifications")]
    public partial class TraktCertificationsModule_Tests
    {
        private const string GET_SHOW_CERTIFICATIONS_URI = "certifications/shows";

        [Fact]
        public async Task Test_TraktCertificationsModule_GetShowCertifications()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, GET_SHOW_CERTIFICATIONS_JSON);
            TraktResponse<ITraktCertifications> response = await client.Certifications.GetShowCertificationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.HasValue.Should().BeTrue();
            response.Exception.Should().BeNull();

            ITraktCertifications certifications = response.Value;
            certifications.US.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(7);

            ITraktCertification[] certificationsUS = certifications.US.ToArray();

            certificationsUS[0].Should().NotBeNull();
            certificationsUS[0].Name.Should().Be("TV-Y");
            certificationsUS[0].Slug.Should().Be("tv-y");
            certificationsUS[0].Description.Should().Be("All Children");

            certificationsUS[1].Should().NotBeNull();
            certificationsUS[1].Name.Should().Be("TV-Y7");
            certificationsUS[1].Slug.Should().Be("tv-y7");
            certificationsUS[1].Description.Should().Be("Older Children - Ages 7+ Recommended");

            certificationsUS[2].Should().NotBeNull();
            certificationsUS[2].Name.Should().Be("TV-G");
            certificationsUS[2].Slug.Should().Be("tv-g");
            certificationsUS[2].Description.Should().Be("All Ages");

            certificationsUS[3].Should().NotBeNull();
            certificationsUS[3].Name.Should().Be("TV-PG");
            certificationsUS[3].Slug.Should().Be("tv-pg");
            certificationsUS[3].Description.Should().Be("Parental Guidance Suggested");

            certificationsUS[4].Should().NotBeNull();
            certificationsUS[4].Name.Should().Be("TV-14");
            certificationsUS[4].Slug.Should().Be("tv-14");
            certificationsUS[4].Description.Should().Be("Parents Strongly Cautioned - Ages 14+ Recommended");

            certificationsUS[5].Should().NotBeNull();
            certificationsUS[5].Name.Should().Be("TV-MA");
            certificationsUS[5].Slug.Should().Be("tv-ma");
            certificationsUS[5].Description.Should().Be("tv-ma");

            certificationsUS[6].Should().NotBeNull();
            certificationsUS[6].Name.Should().Be("Not Rated");
            certificationsUS[6].Slug.Should().Be("nr");
            certificationsUS[6].Description.Should().Be("Not Rated");
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCertificationsModule_GetShowCertifications_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_CERTIFICATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCertifications>>> act = () => client.Certifications.GetShowCertificationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
