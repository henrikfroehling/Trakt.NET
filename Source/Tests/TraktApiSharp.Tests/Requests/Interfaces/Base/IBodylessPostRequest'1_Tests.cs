namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IBodylessPostRequest_1_Tests
    {
        [Fact]
        public void Test_IBodylessPostRequest_1_Is_Interface()
        {
            typeof(IBodylessPostRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IBodylessPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(IBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IBodylessPostRequest_1_Inherits_ITraktRequest_1_Interface()
        {
            typeof(IBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(IRequest<int>));
        }
    }
}
