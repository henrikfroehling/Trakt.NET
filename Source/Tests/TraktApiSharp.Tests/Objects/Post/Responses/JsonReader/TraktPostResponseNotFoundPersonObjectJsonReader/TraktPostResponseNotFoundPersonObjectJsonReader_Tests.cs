namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundPersonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundPersonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundPersonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPostResponseNotFoundPerson>));
        }
    }
}
