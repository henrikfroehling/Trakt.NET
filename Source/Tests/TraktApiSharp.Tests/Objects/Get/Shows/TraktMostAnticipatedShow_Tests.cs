namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktMostAnticipatedShow_Tests
    {
        [Fact]
        public void Test_TraktMostAnticipatedShow_Implements_ITraktMostAnticipatedShow_Interface()
        {
            typeof(TraktMostAnticipatedShow).GetInterfaces().Should().Contain(typeof(ITraktMostAnticipatedShow));
        }
    }
}
