namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class ListsTrendingRequest_Tests
    {
        [Fact]
        public void Test_ListsTrendingRequest_Has_Valid_UriTemplate()
        {
            var request = new ListsTrendingRequest();
            request.UriTemplate.Should().Be("lists/trending{?extended,page,limit}");
        }
    }
}
