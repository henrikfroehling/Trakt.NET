namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSyncItemType_Tests
    {
        [Fact]
        public void Test_TraktSyncItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncItemType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktSyncItemType>() { TraktSyncItemType.Unspecified, TraktSyncItemType.Movie,
                                                                       TraktSyncItemType.Show, TraktSyncItemType.Season,
                                                                       TraktSyncItemType.Episode });
        }
    }
}
