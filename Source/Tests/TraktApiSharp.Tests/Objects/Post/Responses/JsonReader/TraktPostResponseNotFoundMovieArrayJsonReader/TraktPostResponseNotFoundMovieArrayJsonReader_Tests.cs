namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundMovieArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundMovieArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundMovieArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktPostResponseNotFoundMovie>));
        }
    }
}
