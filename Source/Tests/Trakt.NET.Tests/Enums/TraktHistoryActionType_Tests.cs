namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
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
