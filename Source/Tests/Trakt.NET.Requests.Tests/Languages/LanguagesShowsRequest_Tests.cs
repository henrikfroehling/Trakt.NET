namespace TraktNet.Requests.Tests.Languages
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Languages;
    using Xunit;

    [TestCategory("Requests.Languages")]
    public class LanguagesShowsRequest_Tests
    {
        [Fact]
        public void Test_LanguagesShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new LanguagesShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_LanguagesShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new LanguagesShowsRequest();
            request.UriTemplate.Should().Be("languages/shows");
        }

        [Fact]
        public void Test_LanguagesShowsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new LanguagesShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
