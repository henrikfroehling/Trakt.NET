﻿namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Scrobbles.OAuth;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class ScrobbleStopRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public HttpContent ToHttpContent()
            {
                throw new System.NotImplementedException();
            }

            public Task<string> ToJson(CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult("");

            public void Validate()
            {
            }
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new ScrobbleStopRequest<int, RequestBodyMock>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Has_Valid_UriTemplate()
        {
            var request = new ScrobbleStopRequest<int, RequestBodyMock>();
            request.UriTemplate.Should().Be("scrobble/stop");
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new ScrobbleStopRequest<int, RequestBodyMock>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
