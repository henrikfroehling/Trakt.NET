namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Responses;
    using TraktApiSharp.Responses.Interfaces;
    using Xunit;

    [Category("Responses")]
    public class TraktPagedResponse_1_Tests
    {
        [Fact]
        public void Test_TraktPagedResponse_1_Is_NotAbstract()
        {
            typeof(TraktPagedResponse<>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPagedResponse_1_Has_GenericTypeParameter()
        {
            typeof(TraktPagedResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktPagedResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktPagedResponse_1_Inherits_TraktListResponse_1()
        {
            typeof(TraktPagedResponse<int>).IsSubclassOf(typeof(TraktListResponse<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPagedResponse_1_Implements_ITraktPagedResponse_1_Interface()
        {
            typeof(TraktPagedResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktPagedResponse<int>));
        }

        [Fact]
        public void Test_TraktPagedResponse_1_Implements_IEquatable_Interface()
        {
            typeof(TraktPagedResponse<int>).GetInterfaces().Should().Contain(typeof(IEquatable<TraktPagedResponse<int>>));
        }
    }
}
