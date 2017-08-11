namespace TraktApiSharp.Tests.Objects.Post.Users.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Objects.Post.Users.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class TraktUserFollowUserPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktUserFollowUserPostResponseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktUserFollowUserPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktUserFollowUserPostResponse>));
        }
    }
}
