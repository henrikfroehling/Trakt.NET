namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("Objects.Post.Comments.Implementations")]
    public class TraktListCommentPost_Tests
    {
        [Fact]
        public void Test_TraktListCommentPost_Validate()
        {
            ITraktListCommentPost listCommentPost = new TraktListCommentPost();

            // Comment = null
            Action act = () => listCommentPost.Validate();
            act.Should().Throw<ArgumentNullException>();

            // Comment = less than five words
            listCommentPost.Comment = "one two three four";
            act.Should().Throw<ArgumentOutOfRangeException>();

            // List = null
            listCommentPost.Comment = "one two three four five";
            act.Should().Throw<ArgumentNullException>();

            // List Ids = null
            listCommentPost.List = new TraktList();
            act.Should().Throw<ArgumentNullException>();

            // List IDs have no valid id
            listCommentPost.List = new TraktList
            {
                Ids = new TraktListIds()
            };
            act.Should().Throw<ArgumentException>();

            // valid
            listCommentPost.List = new TraktList
            {
                Ids = new TraktListIds { Trakt = 1 }
            };
            act.Should().NotThrow();
        }
    }
}
