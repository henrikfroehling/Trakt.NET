namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Responses;
    using TraktApiSharp.Experimental.Responses.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses")]
    public class TraktListResponse_1_Tests
    {
        [Fact]
        public void Test_TraktListResponse_1_Is_NotAbstract()
        {
            typeof(TraktListResponse<>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktListResponse_1_Has_GenericTypeParameter()
        {
            typeof(TraktListResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktListResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktListResponse_1_Inherits_TraktResponse_1()
        {
            typeof(TraktListResponse<int>).IsSubclassOf(typeof(TraktResponse<IEnumerable<int>>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktListResponse_1_Implements_ITraktListResponse_1_Interface()
        {
            typeof(TraktListResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktListResponse<int>));
        }
    }
}
