namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktPostRequest_2_Tests
    {
        [Fact]
        public void Test_ITraktPostRequest_2_Is_Interface()
        {
            typeof(ITraktPostRequest<,>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostRequest_2_Has_GenericTypeParameter()
        {
            typeof(ITraktPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ITraktPostRequest_2_Inherits_ITraktRequest_1_Interface()
        {
            typeof(ITraktPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }

        [Fact]
        public void Test_ITraktPostRequest_2_Inherits_ITraktHasRequestBody_1_Interface()
        {
            typeof(ITraktPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
