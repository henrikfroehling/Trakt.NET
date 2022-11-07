namespace TraktNet.Requests.Tests.Scrobbles.OAuth
{
    using FluentAssertions;
    using System.Threading;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;
    using TraktNet.Requests.Scrobbles.OAuth;
    using Xunit;

    [TestCategory("Requests.Scrobbles.OAuth")]
    public class ScrobbleStopRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
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
