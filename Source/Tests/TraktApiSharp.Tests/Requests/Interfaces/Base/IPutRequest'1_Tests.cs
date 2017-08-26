namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IPutRequest_1_Tests
    {
        [Fact]
        public void Test_IPutRequest_1_Is_Interface()
        {
            typeof(IPutRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IPutRequest_1_Has_GenericTypeParameter()
        {
            typeof(IPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IPutRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IPutRequest_1_Inherits_ITraktRequest_Interface()
        {
            typeof(IPutRequest<>).GetInterfaces().Should().Contain(typeof(IRequest));
        }

        [Fact]
        public void Test_IPutRequest_1_Inherits_ITraktHasRequestBody_1_Interface()
        {
            typeof(IPutRequest<float>).GetInterfaces().Should().Contain(typeof(IHasRequestBody<float>));
        }
    }
}
