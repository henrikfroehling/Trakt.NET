namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PostResponseNotFoundPersonArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PostResponseNotFoundPersonArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundPerson>));
        }
    }
}
