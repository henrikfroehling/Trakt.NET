namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktHistoryActionType_Tests
    {
        [Fact]
        public void Test_TraktHistoryActionType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHistoryActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHistoryActionType>() { TraktHistoryActionType.Unspecified, TraktHistoryActionType.Scrobble,
                                                                            TraktHistoryActionType.Checkin, TraktHistoryActionType.Watch });
        }
    }
}
