namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Checkins.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class TraktCheckinsDeleteRequest_Tests
    {
        [Fact]
        public void Test_TraktCheckinsDeleteRequest_IsNotAbstract()
        {
            typeof(TraktCheckinsDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCheckinsDeleteRequest_IsSealed()
        {
            typeof(TraktCheckinsDeleteRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCheckinsDeleteRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(TraktCheckinsDeleteRequest).IsSubclassOf(typeof(ATraktDeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCheckinsDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktCheckinsDeleteRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCheckinsDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCheckinsDeleteRequest();
            request.UriTemplate.Should().Be("checkin");
        }

        [Fact]
        public void Test_TraktCheckinsDeleteRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktCheckinsDeleteRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
