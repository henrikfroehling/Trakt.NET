namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Responses.Interfaces;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktPagedResponse_1_Tests
    {
        [Fact]
        public void Test_ITraktPagedResponse_1_Is_Interface()
        {
            typeof(ITraktPagedResponse<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPagedResponse_1_Has_GenericTypeParameter()
        {
            typeof(ITraktPagedResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPagedResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktPagedResponse_1_Inherits_ITraktListResponse_1_Interface()
        {
            typeof(ITraktPagedResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktListResponse<int>));
        }

        [Fact]
        public void Test_ITraktPagedResponse_1_Inherits_ITraktPagedResponseHeaders_Interface()
        {
            typeof(ITraktPagedResponse<>).GetInterfaces().Should().Contain(typeof(ITraktPagedResponseHeaders));
        }
    }
}
