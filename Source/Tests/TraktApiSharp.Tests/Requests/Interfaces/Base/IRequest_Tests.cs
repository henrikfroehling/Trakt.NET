namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IRequest_Tests
    {
        [Fact]
        public void Test_IRequest_Is_Interface()
        {
            typeof(IRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IRequest_Inherits_IHttpRequest_Interface()
        {
            typeof(IRequest).GetInterfaces().Should().Contain(typeof(IHttpRequest));
        }

        [Fact]
        public void Test_IRequest_Inherits_IHasRequestAuthorization_Interface()
        {
            typeof(IRequest).GetInterfaces().Should().Contain(typeof(IHasRequestAuthorization));
        }

        [Fact]
        public void Test_IRequest_Inherits_IHasUri_Interface()
        {
            typeof(IRequest).GetInterfaces().Should().Contain(typeof(IHasUri));
        }

        [Fact]
        public void Test_IRequest_Inherits_IValidatable_Interface()
        {
            typeof(IRequest).GetInterfaces().Should().Contain(typeof(IValidatable));
        }
    }
}
