namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class CheckinPostErrorResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CheckinPostErrorResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CheckinPostErrorResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCheckinPostErrorResponse>));
        }
    }
}
