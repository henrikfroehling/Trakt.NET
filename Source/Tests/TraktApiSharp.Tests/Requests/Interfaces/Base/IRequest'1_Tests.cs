namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IRequest_1_Tests
    {
        [Fact]
        public void Test_IRequest_1_Is_Interface()
        {
            typeof(IRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IRequest_1_Has_GenericTypeParameter()
        {
            typeof(IRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IRequest_1_Inherits_ITraktRequest_Interface()
        {
            typeof(IRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
