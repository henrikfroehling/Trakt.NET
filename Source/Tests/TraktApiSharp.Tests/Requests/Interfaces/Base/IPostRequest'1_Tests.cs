namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IPostRequest_1_Tests
    {
        [Fact]
        public void Test_IPostRequest_1_Is_Interface()
        {
            typeof(IPostRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(IPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IPostRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IPostRequest_1_Inherits_IRequest_Interface()
        {
            typeof(IPostRequest<>).GetInterfaces().Should().Contain(typeof(IRequest));
        }

        [Fact]
        public void Test_IPostRequest_1_Inherits_IHasRequestBody_1_Interface()
        {
            typeof(IPostRequest<float>).GetInterfaces().Should().Contain(typeof(IHasRequestBody<float>));
        }
    }
}
