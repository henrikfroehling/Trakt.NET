namespace TraktNet.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Checkins.OAuth;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class CheckinsDeleteRequest_Tests
    {
        [Fact]
        public void Test_CheckinsDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new CheckinsDeleteRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CheckinsDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new CheckinsDeleteRequest();
            request.UriTemplate.Should().Be("checkin");
        }

        [Fact]
        public void Test_CheckinsDeleteRequest_Returns_Valid_UriPathParameters()
        {
            var request = new CheckinsDeleteRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
