namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktRequest_Tests
    {
        [Fact]
        public void Test_ITraktRequest_Is_Interface()
        {
            typeof(ITraktRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktHttpRequest_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(IHttpRequest));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktHasRequestAuthorization_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(IHasRequestAuthorization));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktHasUri_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(IHasUri));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktValidatable_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }
    }
}
