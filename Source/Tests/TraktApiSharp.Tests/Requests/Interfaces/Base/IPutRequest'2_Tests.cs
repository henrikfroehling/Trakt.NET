namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IPutRequest_2_Tests
    {
        [Fact]
        public void Test_IPutRequest_2_Is_Interface()
        {
            typeof(IPutRequest<,>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IPutRequest_2_Has_GenericTypeParameter()
        {
            typeof(IPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(IPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_IPutRequest_2_Inherits_IRequest_1_Interface()
        {
            typeof(IPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(IRequest<int>));
        }

        [Fact]
        public void Test_IPutRequest_2_Inherits_IHasRequestBody_1_Interface()
        {
            typeof(IPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(IHasRequestBody<float>));
        }
    }
}
