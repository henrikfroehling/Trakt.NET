namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
    public class SingleListRequest_Tests
    {
        [Fact]
        public void Test_SingleListRequest_Has_Valid_UriTemplate()
        {
            var request = new SingleListRequest();
            request.UriTemplate.Should().Be("lists/{id}");
        }
    }
}
