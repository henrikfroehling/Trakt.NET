namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using System;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Checkins.OAuth;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class CheckinRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public string HttpContentAsString => throw new NotImplementedException();

            public HttpContent ToHttpContent() => throw new NotImplementedException();

            public void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_CheckinRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new CheckinRequest<int, RequestBodyMock>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CheckinRequest_2_Has_Valid_UriTemplate()
        {
            var request = new CheckinRequest<int, RequestBodyMock>();
            request.UriTemplate.Should().Be("checkin");
        }

        [Fact]
        public void Test_CheckinRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new CheckinRequest<int, RequestBodyMock>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
