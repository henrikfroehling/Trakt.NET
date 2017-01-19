namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
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
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHttpRequest));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktHasRequestAuthorization_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHasRequestAuthorization));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktHasUri_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHasUri));
        }

        [Fact]
        public void Test_ITraktRequest_Inherits_ITraktValidatable_Interface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }
    }
}
