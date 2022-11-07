namespace TraktNet.Requests.Tests.Languages
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Languages;
    using Xunit;

    [TestCategory("Requests.Languages")]
    public class LanguagesMoviesRequest_Tests
    {
        [Fact]
        public void Test_LanguagesMoviesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new LanguagesMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_LanguagesMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new LanguagesMoviesRequest();
            request.UriTemplate.Should().Be("languages/movies");
        }

        [Fact]
        public void Test_LanguagesMoviesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new LanguagesMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
