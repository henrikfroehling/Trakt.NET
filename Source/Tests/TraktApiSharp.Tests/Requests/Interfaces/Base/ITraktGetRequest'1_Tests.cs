namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktGetRequest_1_Tests
    {
        [Fact]
        public void Test_ITraktGetRequest_1_Is_Interface()
        {
            typeof(ITraktGetRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ITraktGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktGetRequest_1_Inherits_ITraktRequest_1_Interface()
        {
            typeof(ITraktGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }
    }
}
