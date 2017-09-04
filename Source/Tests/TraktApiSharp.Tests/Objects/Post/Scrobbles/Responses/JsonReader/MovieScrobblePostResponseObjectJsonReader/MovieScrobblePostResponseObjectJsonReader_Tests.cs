namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class MovieScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_MovieScrobblePostResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(MovieScrobblePostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMovieScrobblePostResponse>));
        }
    }
}
