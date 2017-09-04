namespace TraktApiSharp.Tests.Objects.Post.Users.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Objects.Post.Users.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserFollowUserPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_UserFollowUserPostResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(UserFollowUserPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktUserFollowUserPostResponse>));
        }
    }
}
