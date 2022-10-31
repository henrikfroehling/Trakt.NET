namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktUserLikeType_Tests
    {
        [Fact]
        public void Test_TraktUserLikeType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktUserLikeType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktUserLikeType>() { TraktUserLikeType.Unspecified, TraktUserLikeType.Comment,
                                                                       TraktUserLikeType.List });
        }
    }
}
