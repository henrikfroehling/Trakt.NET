namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IGetRequest_1_Tests
    {
        [Fact]
        public void Test_IGetRequest_1_Is_Interface()
        {
            typeof(IGetRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(IGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IGetRequest_1_Inherits_ITraktRequest_1_Interface()
        {
            typeof(IGetRequest<int>).GetInterfaces().Should().Contain(typeof(IRequest<int>));
        }
    }
}
