namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserHiddenItemsRemoveRequest_Tests
    {
        [Fact]
        public void Test_UserHiddenItemsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new UserHiddenItemsRemoveRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}/remove");
        }
    }
}
