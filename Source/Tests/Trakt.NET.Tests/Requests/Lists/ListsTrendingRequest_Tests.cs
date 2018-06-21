namespace TraktNet.Tests.Requests.Lists
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
    public class ListsTrendingRequest_Tests
    {
        [Fact]
        public void Test_ListsTrendingRequest_Has_Valid_UriTemplate()
        {
            var request = new ListsTrendingRequest();
            request.UriTemplate.Should().Be("lists/trending{?page,limit}");
        }
    }
}
