namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PostResponseNotFoundMovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PostResponseNotFoundMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPostResponseNotFoundMovie>));
        }
    }
}
