namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PostResponseNotFoundShowArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PostResponseNotFoundShowArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPostResponseNotFoundShow>));
        }
    }
}
