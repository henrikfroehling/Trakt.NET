namespace TraktNet.Requests.Tests.Countries
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Countries;
    using Xunit;

    [TestCategory("Requests.Countries")]
    public class CountriesMoviesRequest_Tests
    {
        [Fact]
        public void Test_CountriesMoviesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CountriesMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CountriesMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new CountriesMoviesRequest();
            request.UriTemplate.Should().Be("countries/movies");
        }

        [Fact]
        public void Test_CountriesMoviesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new CountriesMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
