namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IPostRequest_2_Tests
    {
        [Fact]
        public void Test_IPostRequest_2_Is_Interface()
        {
            typeof(IPostRequest<,>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IPostRequest_2_Has_GenericTypeParameter()
        {
            typeof(IPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(IPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_IPostRequest_2_Inherits_IRequest_1_Interface()
        {
            typeof(IPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(IRequest<int>));
        }

        [Fact]
        public void Test_IPostRequest_2_Inherits_IHasRequestBody_1_Interface()
        {
            typeof(IPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(IHasRequestBody<float>));
        }
    }
}
