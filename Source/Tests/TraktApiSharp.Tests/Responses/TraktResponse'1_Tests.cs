namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Responses;
    using TraktApiSharp.Responses.Interfaces;
    using Xunit;

    [Category("Responses")]
    public class TraktResponse_1_Tests
    {
        [Fact]
        public void Test_TraktResponse_1_Is_NotAbstract()
        {
            typeof(TraktResponse<>).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktResponse_1_Has_GenericTypeParameter()
        {
            typeof(TraktResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktResponse_1_Inherits_TraktNoContentResponse()
        {
            typeof(TraktResponse<>).IsSubclassOf(typeof(TraktNoContentResponse)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktResponse_1_Implements_ITraktResponse_1_Interface()
        {
            typeof(TraktResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktResponse<int>));
        }

        [Fact]
        public void Test_TraktResponse_1_Implements_IEquatable_Interface()
        {
            typeof(TraktResponse<int>).GetInterfaces().Should().Contain(typeof(IEquatable<TraktResponse<int>>));
        }
    }
}
