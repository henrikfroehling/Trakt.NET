namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Scrobbles.OAuth;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class ScrobbleStartRequest_2_Tests
    {
        [Fact]
        public void Test_ScrobbleStartRequest_2_IsNotAbstract()
        {
            typeof(ScrobbleStartRequest<,>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_IsSealed()
        {
            typeof(ScrobbleStartRequest<,>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_GenericTypeParameter()
        {
            typeof(ScrobbleStartRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ScrobbleStartRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Inherits_ATraktPostRequest_2()
        {
            typeof(ScrobbleStartRequest<int, float>).IsSubclassOf(typeof(APostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new ScrobbleStartRequest<int, float>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_Valid_UriTemplate()
        {
            var request = new ScrobbleStartRequest<int, float>();
            request.UriTemplate.Should().Be("scrobble/start");
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new ScrobbleStartRequest<int, float>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
