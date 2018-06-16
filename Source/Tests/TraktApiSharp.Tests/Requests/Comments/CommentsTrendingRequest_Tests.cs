namespace TraktApiSharp.Tests.Requests.Comments
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Comments;
    using Xunit;

    [Category("Requests.Comments")]
    public class CommentsTrendingRequest_Tests
    {
        [Fact]
        public void Test_CommentsTrendingRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentsTrendingRequest();
            request.UriTemplate.Should().Be("comments/trending{/comment_type}{/object_type}{?include_replies,extended,page,limit}");
        }
    }
}
