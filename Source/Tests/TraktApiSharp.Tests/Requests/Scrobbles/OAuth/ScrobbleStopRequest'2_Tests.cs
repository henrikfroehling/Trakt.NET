namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Scrobbles.OAuth;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class ScrobbleStopRequest_2_Tests
    {
        [Fact]
        public void Test_ScrobbleStopRequest_2_IsNotAbstract()
        {
            typeof(ScrobbleStopRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_IsSealed()
        {
            typeof(ScrobbleStopRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Has_GenericTypeParameter()
        {
            typeof(ScrobbleStopRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ScrobbleStopRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(ScrobbleStopRequest<int, float>).IsSubclassOf(typeof(APostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new ScrobbleStopRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Has_Valid_UriTemplate()
        {
            var request = new ScrobbleStopRequest<int, float>();
            request.UriTemplate.Should().Be("scrobble/stop");
        }

        [Fact]
        public void Test_ScrobbleStopRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new ScrobbleStopRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
