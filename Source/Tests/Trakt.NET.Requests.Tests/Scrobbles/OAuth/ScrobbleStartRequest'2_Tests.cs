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
    public class ScrobbleStartRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public Task<string> ToJson(CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult("");

            public void Validate()
            {
            }
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_Valid_UriTemplate()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.UriTemplate.Should().Be("scrobble/start");
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
