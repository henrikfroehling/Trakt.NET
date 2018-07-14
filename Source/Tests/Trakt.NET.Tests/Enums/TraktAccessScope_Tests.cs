namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktAccessScope_Tests
    {
        [Fact]
        public void Test_TraktAccessScope_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessScope>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktAccessScope>() { TraktAccessScope.Unspecified, TraktAccessScope.Private,
                                                                      TraktAccessScope.Public, TraktAccessScope.Friends });
        }
    }
}
