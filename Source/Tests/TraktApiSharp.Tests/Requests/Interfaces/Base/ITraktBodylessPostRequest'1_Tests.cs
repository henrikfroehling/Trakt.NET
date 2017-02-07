namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktBodylessPostRequest_1_Tests
    {
        [Fact]
        public void Test_ITraktBodylessPostRequest_1_Is_Interface()
        {
            typeof(ITraktBodylessPostRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktBodylessPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(ITraktBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktBodylessPostRequest_1_Inherits_ITraktRequest_1_Interface()
        {
            typeof(ITraktBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }
    }
}
