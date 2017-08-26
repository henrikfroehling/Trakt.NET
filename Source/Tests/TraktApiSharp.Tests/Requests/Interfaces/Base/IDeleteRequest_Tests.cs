namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IDeleteRequest_Tests
    {
        [Fact]
        public void Test_IDeleteRequest_Is_Interface()
        {
            typeof(IDeleteRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IDeleteRequest_Inherits_ITraktRequest_Interface()
        {
            typeof(IDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
