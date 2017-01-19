namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktPutRequest_1_Tests
    {
        [Fact]
        public void Test_ITraktPutRequest_1_Is_Interface()
        {
            typeof(ITraktPutRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPutRequest_1_Has_GenericTypeParameter()
        {
            typeof(ITraktPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPutRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktPutRequest_1_Inherits_ITraktRequest_Interface()
        {
            typeof(ITraktPutRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [Fact]
        public void Test_ITraktPutRequest_1_Inherits_ITraktHasRequestBody_1_Interface()
        {
            typeof(ITraktPutRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
