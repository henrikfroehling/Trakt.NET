namespace TraktNet.Requests.Tests.Countries
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Countries;
    using Xunit;

    [TestCategory("Requests.Countries")]
    public class CountriesShowsRequest_Tests
    {
        [Fact]
        public void Test_CountriesShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CountriesShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CountriesShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new CountriesShowsRequest();
            request.UriTemplate.Should().Be("countries/shows");
        }

        [Fact]
        public void Test_CountriesShowsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new CountriesShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
