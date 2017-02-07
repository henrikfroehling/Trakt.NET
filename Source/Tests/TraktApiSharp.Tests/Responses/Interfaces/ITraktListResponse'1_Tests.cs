namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Responses.Interfaces;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktListResponse_1_Tests
    {
        [Fact]
        public void Test_ITraktListResponse_1_Is_Interface()
        {
            typeof(ITraktListResponse<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktListResponse_1_Has_GenericTypeParameter()
        {
            typeof(ITraktListResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktListResponse_1_Inherits_ITraktResponse_1_Interface()
        {
            typeof(ITraktListResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktResponse<IEnumerable<int>>));
        }

        [Fact]
        public void Test_ITraktListResponse_1_Inherits_IEnumerable_1_Interface()
        {
            typeof(ITraktListResponse<int>).GetInterfaces().Should().Contain(typeof(IEnumerable<int>));
        }
    }
}
