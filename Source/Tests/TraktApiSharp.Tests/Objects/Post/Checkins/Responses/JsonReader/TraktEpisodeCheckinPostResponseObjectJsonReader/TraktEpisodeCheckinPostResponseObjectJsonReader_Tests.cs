namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class TraktEpisodeCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCheckinPostResponseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktEpisodeCheckinPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeCheckinPostResponse>));
        }
    }
}
