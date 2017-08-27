namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Checkins.OAuth;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class CheckinsDeleteRequest_Tests
    {
        [Fact]
        public void Test_CheckinsDeleteRequest_IsNotAbstract()
        {
            typeof(CheckinsDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_CheckinsDeleteRequest_IsSealed()
        {
            typeof(CheckinsDeleteRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_CheckinsDeleteRequest_Inherits_ADeleteRequest()
        {
            typeof(CheckinsDeleteRequest).IsSubclassOf(typeof(ADeleteRequest)).Should().BeTrue();
        }

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
