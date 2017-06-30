namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class TraktMovieCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMovieCheckinPostResponseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMovieCheckinPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMovieCheckinPostResponse>));
        }
    }
}
