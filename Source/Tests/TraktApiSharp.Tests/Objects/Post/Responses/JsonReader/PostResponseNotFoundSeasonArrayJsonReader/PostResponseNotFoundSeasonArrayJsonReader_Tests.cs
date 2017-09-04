namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PostResponseNotFoundSeasonArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PostResponseNotFoundSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundSeason>));
        }
    }
}
