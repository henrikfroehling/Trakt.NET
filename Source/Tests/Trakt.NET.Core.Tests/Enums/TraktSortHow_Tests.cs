namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktSortHow_Tests
    {
        [Fact]
        public void Test_TraktSortHow_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSortHow>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktSortHow>() { TraktSortHow.Unspecified, TraktSortHow.Ascending,
                                                                  TraktSortHow.Descending });
        }
    }
}
