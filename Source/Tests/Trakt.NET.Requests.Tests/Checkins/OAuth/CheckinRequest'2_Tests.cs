namespace TraktNet.Requests.Tests.Checkins.OAuth
{
    using FluentAssertions;
    using System.Threading;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Checkins.OAuth;
    using TraktNet.Requests.Interfaces;
    using Xunit;

    [TestCategory("Requests.Checkins.OAuth")]
    public class CheckinRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public Task<string> ToJson(CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult("");

            public void Validate()
            {
            }
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
