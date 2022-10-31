namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Comments;
    using Xunit;

    [TestCategory("Requests.Comments")]
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
