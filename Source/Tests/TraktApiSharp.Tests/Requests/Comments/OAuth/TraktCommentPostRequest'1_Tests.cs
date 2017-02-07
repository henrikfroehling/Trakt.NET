namespace TraktApiSharp.Tests.Requests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Objects.Post.Comments;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments.OAuth;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class TraktCommentPostRequest_1_Tests
    {
        [Fact]
        public void Test_TraktCommentPostRequest_1_IsNotAbstract()
        {
            typeof(TraktCommentPostRequest<>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_IsSealed()
        {
            typeof(TraktCommentPostRequest<>).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(TraktCommentPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktCommentPostRequest<TraktCommentPost>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktCommentPostRequest<TraktCommentPost>).IsSubclassOf(typeof(ATraktPostRequest<TraktCommentPostResponse, TraktCommentPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktCommentPostRequest<TraktCommentPost>();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentPostRequest<TraktCommentPost>();
            request.UriTemplate.Should().Be("comments");
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Validate_Throws_ArgumentNullException()
        {
            var request = new TraktCommentPostRequest<TraktCommentPost>();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktCommentPostRequest_1_Returns_Valid_UriPathParameters()
        {
            var request = new TraktCommentPostRequest<TraktCommentPost>();
            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty().And.HaveCount(0);
        }
    }
}
