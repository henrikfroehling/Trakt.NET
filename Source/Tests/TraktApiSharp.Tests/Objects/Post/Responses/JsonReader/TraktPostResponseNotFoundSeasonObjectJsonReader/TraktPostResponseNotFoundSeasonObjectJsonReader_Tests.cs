namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundSeasonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundSeasonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPostResponseNotFoundSeason>));
        }
    }
}
