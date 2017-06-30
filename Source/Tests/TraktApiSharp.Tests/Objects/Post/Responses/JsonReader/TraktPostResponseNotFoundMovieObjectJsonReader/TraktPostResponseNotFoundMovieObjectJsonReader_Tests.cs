namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPostResponseNotFoundMovie>));
        }
    }
}
