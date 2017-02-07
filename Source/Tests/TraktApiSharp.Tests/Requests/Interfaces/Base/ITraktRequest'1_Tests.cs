namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktRequest_1_Tests
    {
        [Fact]
        public void Test_ITraktRequest_1_Is_Interface()
        {
            typeof(ITraktRequest<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRequest_1_Has_GenericTypeParameter()
        {
            typeof(ITraktRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktRequest_1_Inherits_ITraktRequest_Interface()
        {
            typeof(ITraktRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
