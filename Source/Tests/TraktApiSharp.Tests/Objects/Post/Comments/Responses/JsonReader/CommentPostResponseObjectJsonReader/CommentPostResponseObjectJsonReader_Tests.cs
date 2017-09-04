namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Objects.Post.Comments.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.JsonReader")]
    public partial class CommentPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CommentPostResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CommentPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCommentPostResponse>));
        }
    }
}
