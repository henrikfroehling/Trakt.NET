namespace TraktApiSharp.Tests.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Checkins.OAuth;
    using Xunit;

    [Category("Requests.Checkins.OAuth")]
    public class CheckinRequest_2_Tests
    {
        [Fact]
        public void Test_CheckinRequest_2_IsNotAbstract()
        {
            typeof(CheckinRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_CheckinRequest_2_IsSealed()
        {
            typeof(CheckinRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_CheckinRequest_2_Has_GenericTypeParameter()
        {
            typeof(CheckinRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(CheckinRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_CheckinRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(CheckinRequest<int, float>).IsSubclassOf(typeof(APostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_CheckinRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new CheckinRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CheckinRequest_2_Has_Valid_UriTemplate()
        {
            var request = new CheckinRequest<int, float>();
            request.UriTemplate.Should().Be("checkin");
        }

        [Fact]
        public void Test_CheckinRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new CheckinRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
