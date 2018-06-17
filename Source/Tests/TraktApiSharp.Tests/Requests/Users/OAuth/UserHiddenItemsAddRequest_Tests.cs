namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserHiddenItemsAddRequest_Tests
    {
        [Fact]
        public void Test_UserHiddenItemsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserHiddenItemsAddRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}");
        }
    }
}
