namespace TraktNet.Tests.Requests.Comments
{
    using FluentAssertions;
    using Traits;
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
