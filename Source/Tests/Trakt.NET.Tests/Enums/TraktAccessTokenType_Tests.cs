namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktAccessTokenType_Tests
    {
        [Fact]
        public void Test_TraktAccessTokenType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenType>();

            allValues.Should().NotBeNull().And.HaveCount(2);
            allValues.Should().Contain(new List<TraktAccessTokenType>() { TraktAccessTokenType.Unspecified, TraktAccessTokenType.Bearer });
        }
    }
}
