namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PostResponseNotFoundEpisodeArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PostResponseNotFoundEpisodeArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundEpisode>));
        }
    }
}
