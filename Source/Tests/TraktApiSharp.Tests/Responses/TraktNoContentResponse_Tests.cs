namespace TraktApiSharp.Tests.Responses
{
    using FluentAssertions;
    using System;
    using TraktApiSharp.Experimental.Responses;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses")]
    public class TraktNoContentResponse_Tests
    {
        [Fact]
        public void Test_TraktNoContentResponse_Is_NotAbstract()
        {
            typeof(TraktNoContentResponse).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktNoContentResponse_Implements_ITraktNoContentResponse_Interface()
        {
            typeof(TraktNoContentResponse).GetInterfaces().Should().Contain(typeof(ITraktNoContentResponse));
        }

        [Fact]
        public void Test_TraktNoContentResponse_Implements_IEquatable_Interface()
        {
            typeof(TraktNoContentResponse).GetInterfaces().Should().Contain(typeof(IEquatable<TraktNoContentResponse>));
        }
    }
}
