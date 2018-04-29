namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
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
