namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Comments;
    using Xunit;

    [Category("Requests.Comments")]
    public class CommentsUpdatesRequest_Tests
    {
        [Fact]
        public void Test_CommentsUpdatesRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentsUpdatesRequest();
            request.UriTemplate.Should().Be("comments/updates{/comment_type}{/object_type}{?include_replies,extended,page,limit}");
        }
    }
}
