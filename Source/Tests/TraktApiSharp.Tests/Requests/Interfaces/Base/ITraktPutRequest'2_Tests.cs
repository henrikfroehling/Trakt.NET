namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktPutRequest_2_Tests
    {
        [Fact]
        public void Test_ITraktPutRequest_2_Is_Interface()
        {
            typeof(ITraktPutRequest<,>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPutRequest_2_Has_GenericTypeParameter()
        {
            typeof(ITraktPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ITraktPutRequest_2_Inherits_ITraktRequest_1_Interface()
        {
            typeof(ITraktPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }

        [Fact]
        public void Test_ITraktPutRequest_2_Inherits_ITraktHasRequestBody_1_Interface()
        {
            typeof(ITraktPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
