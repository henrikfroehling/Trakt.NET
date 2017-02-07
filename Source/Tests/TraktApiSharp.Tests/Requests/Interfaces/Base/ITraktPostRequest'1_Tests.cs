namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktPostRequest_1_Tests
    {
        [Fact]
        public void Test_ITraktPostRequest_1_Is_Interface()
        {
            typeof(ITraktPostRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(ITraktPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPostRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktPostRequest_1_Inherits_ITraktRequest_Interface()
        {
            typeof(ITraktPostRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [Fact]
        public void Test_ITraktPostRequest_1_Inherits_ITraktHasRequestBody_1_Interface()
        {
            typeof(ITraktPostRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
