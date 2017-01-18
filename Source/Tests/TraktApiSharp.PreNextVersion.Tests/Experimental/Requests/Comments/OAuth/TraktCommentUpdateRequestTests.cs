namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;
    using TraktApiSharp.Objects.Post.Comments.Responses;

    [TestClass]
    public class TraktCommentUpdateRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentUpdateRequestIsNotAbstract()
        {
            typeof(TraktCommentUpdateRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentUpdateRequestIsSealed()
        {
            typeof(TraktCommentUpdateRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentUpdateRequestIsSubclassOfATraktSingleItemPutByIdRequest()
        {
            typeof(TraktCommentUpdateRequest).IsSubclassOf(typeof(ATraktSingleItemPutByIdRequest<TraktCommentPostResponse, TraktCommentUpdatePost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentUpdateRequestHasValidUriTemplate()
        {
            var request = new TraktCommentUpdateRequest(null);
            request.UriTemplate.Should().Be("comments/{id}");
        }
    }
}
