namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class ListsPopularRequest_Tests
    {
        [Fact]
        public void Test_ListsPopularRequest_Has_Valid_UriTemplate()
        {
            var request = new ListsPopularRequest();
            request.UriTemplate.Should().Be("lists/popular{?page,limit}");
        }
    }
}
