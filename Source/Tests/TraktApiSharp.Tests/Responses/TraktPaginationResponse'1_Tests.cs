namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System;
    using TraktApiSharp.Experimental.Responses;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses")]
    public class TraktPaginationResponse_1_Tests
    {
        [Fact]
        public void Test_TraktPaginationResponse_1_Is_NotAbstract()
        {
            typeof(TraktPaginationResponse<>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPaginationResponse_1_Has_GenericTypeParameter()
        {
            typeof(TraktPaginationResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktPaginationResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktPaginationResponse_1_Inherits_TraktListResponse_1()
        {
            typeof(TraktPaginationResponse<int>).IsSubclassOf(typeof(TraktListResponse<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPaginationResponse_1_Implements_ITraktPaginationResponse_1_Interface()
        {
            typeof(TraktPaginationResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktPagedResponse<int>));
        }

        [Fact]
        public void Test_TraktPaginationResponse_1_Implements_IEquatable_Interface()
        {
            typeof(TraktPaginationResponse<int>).GetInterfaces().Should().Contain(typeof(IEquatable<TraktPaginationResponse<int>>));
        }
    }
}
