namespace TraktNet.Tests.Requests.Lists
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
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
