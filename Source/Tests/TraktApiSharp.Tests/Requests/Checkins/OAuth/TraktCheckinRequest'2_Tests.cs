namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Checkins.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class TraktCheckinRequest_2_Tests
    {
        [Fact]
        public void Test_TraktCheckinRequest_2_IsNotAbstract()
        {
            typeof(TraktCheckinRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_IsSealed()
        {
            typeof(TraktCheckinRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_Has_GenericTypeParameter()
        {
            typeof(TraktCheckinRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktCheckinRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktCheckinRequest<int, float>).IsSubclassOf(typeof(ATraktPostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktCheckinRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_Has_Valid_UriTemplate()
        {
            var request = new TraktCheckinRequest<int, float>();
            request.UriTemplate.Should().Be("checkin");
        }

        [Fact]
        public void Test_TraktCheckinRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new TraktCheckinRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
