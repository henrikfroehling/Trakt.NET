namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Responses;
    using TraktApiSharp.Responses.Interfaces;
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

        [Fact]
        public void Test_TraktListResponse_1_Implements_IEquatable_Interface()
        {
            typeof(TraktListResponse<int>).GetInterfaces().Should().Contain(typeof(IEquatable<TraktListResponse<int>>));
        }
    }
}
