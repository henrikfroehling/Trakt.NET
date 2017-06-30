namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.Implementations;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Implementations")]
    public class TraktCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_TraktCheckinPostResponse_Implements_ITraktCheckinPostResponse_Interface()
        {
            typeof(TraktCheckinPostResponse).GetInterfaces().Should().Contain(typeof(ITraktCheckinPostResponse));
        }
    }
}
