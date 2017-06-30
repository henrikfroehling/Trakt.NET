namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundEpisodeObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundEpisodeObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPostResponseNotFoundEpisode>));
        }
    }
}
