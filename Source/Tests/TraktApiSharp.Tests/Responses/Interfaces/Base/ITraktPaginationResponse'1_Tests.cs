namespace TraktApiSharp.Tests.Responses.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses.Interfaces.Base")]
    public class ITraktPaginationResponse_1_Tests
    {
        [Fact]
        public void Test_ITraktPaginationResponse_1_Is_Interface()
        {
            typeof(ITraktPaginationResponse<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPaginationResponse_1_Has_GenericTypeParameter()
        {
            typeof(ITraktPaginationResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktPaginationResponse_1_Inherits_ITraktListResponse_1_Interface()
        {
            typeof(ITraktPaginationResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktListResponse<int>));
        }

        [Fact]
        public void Test_ITraktPaginationResponse_1_Inherits_ITraktPaginationResponseHeaders_Interface()
        {
            typeof(ITraktPaginationResponse<>).GetInterfaces().Should().Contain(typeof(ITraktPaginationResponseHeaders));
        }
    }
}
