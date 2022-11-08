namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Threading;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class ASyncPostRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public Task<string> ToJson(CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult("");

            public void Validate()
            {
            }
        }

        internal class SyncPostRequestMock : ASyncPostRequest<int, RequestBodyMock>
        {
            public override string UriTemplate => "";
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncPostRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new SyncPostRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
