namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundSeasonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundSeasonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundSeason>));
        }
    }
}
