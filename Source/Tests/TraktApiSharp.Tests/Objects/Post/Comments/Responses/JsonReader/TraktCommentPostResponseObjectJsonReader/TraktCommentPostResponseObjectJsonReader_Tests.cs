namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Objects.Post.Comments.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.JsonReader")]
    public partial class TraktCommentPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCommentPostResponseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCommentPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCommentPostResponse>));
        }
    }
}
