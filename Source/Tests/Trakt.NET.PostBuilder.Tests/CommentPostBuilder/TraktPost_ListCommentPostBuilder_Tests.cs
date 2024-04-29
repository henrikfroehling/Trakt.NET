namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_ListCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Empty_Build()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Comment_List()
        {
            ITraktListCommentPost listCommentPost = TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .Build();

            listCommentPost.Should().NotBeNull();
            listCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            listCommentPost.List.Should().NotBeNull();
            listCommentPost.List.Ids.Should().NotBeNull();
            listCommentPost.List.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Trakt);
            listCommentPost.List.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Slug);
            listCommentPost.Sharing.Should().BeNull();
            listCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Comment_ListIds()
        {
            ITraktListCommentPost listCommentPost = TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST_IDS)
                .Build();

            listCommentPost.Should().NotBeNull();
            listCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            listCommentPost.List.Should().NotBeNull();
            listCommentPost.List.Ids.Should().NotBeNull();
            listCommentPost.List.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.LIST_IDS.Trakt);
            listCommentPost.List.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.LIST_IDS.Slug);
            listCommentPost.Sharing.Should().BeNull();
            listCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Comment_List_Sharing()
        {
            ITraktListCommentPost listCommentPost = TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            listCommentPost.Should().NotBeNull();
            listCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            listCommentPost.List.Should().NotBeNull();
            listCommentPost.List.Ids.Should().NotBeNull();
            listCommentPost.List.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Trakt);
            listCommentPost.List.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Slug);
            listCommentPost.Sharing.Should().NotBeNull();
            listCommentPost.Sharing.Apple.Should().BeTrue();
            listCommentPost.Sharing.Facebook.Should().BeTrue();
            listCommentPost.Sharing.Google.Should().BeTrue();
            listCommentPost.Sharing.Medium.Should().BeTrue();
            listCommentPost.Sharing.Slack.Should().BeTrue();
            listCommentPost.Sharing.Tumblr.Should().BeTrue();
            listCommentPost.Sharing.Twitter.Should().BeTrue();
            listCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Comment_List_Spoiler()
        {
            ITraktListCommentPost listCommentPost = TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .WithSpoiler(true)
                .Build();

            listCommentPost.Should().NotBeNull();
            listCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            listCommentPost.List.Should().NotBeNull();
            listCommentPost.List.Ids.Should().NotBeNull();
            listCommentPost.List.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Trakt);
            listCommentPost.List.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Slug);
            listCommentPost.Sharing.Should().BeNull();
            listCommentPost.Spoiler.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_Complete()
        {
            ITraktListCommentPost listCommentPost = TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .WithSpoiler(true)
                .Build();

            listCommentPost.Should().NotBeNull();
            listCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            listCommentPost.List.Should().NotBeNull();
            listCommentPost.List.Ids.Should().NotBeNull();
            listCommentPost.List.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Trakt);
            listCommentPost.List.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.LIST.Ids.Slug);
            listCommentPost.Sharing.Should().NotBeNull();
            listCommentPost.Sharing.Apple.Should().BeTrue();
            listCommentPost.Sharing.Facebook.Should().BeTrue();
            listCommentPost.Sharing.Google.Should().BeTrue();
            listCommentPost.Sharing.Medium.Should().BeTrue();
            listCommentPost.Sharing.Slack.Should().BeTrue();
            listCommentPost.Sharing.Tumblr.Should().BeTrue();
            listCommentPost.Sharing.Twitter.Should().BeTrue();
            listCommentPost.Spoiler.Should().BeTrue();
        }
    }
}
