namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundPersonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundPersonArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktPostResponseNotFoundPersonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundPerson>));
        }
    }
}
