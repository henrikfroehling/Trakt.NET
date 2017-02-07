namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktDeleteRequest_Tests
    {
        [Fact]
        public void Test_ITraktDeleteRequest_Is_Interface()
        {
            typeof(ITraktDeleteRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktDeleteRequest_Inherits_ITraktRequest_Interface()
        {
            typeof(ITraktDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
