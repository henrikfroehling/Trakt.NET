namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncHistoryActionTypeTests
    {
        [TestMethod]
        public void TestTraktSyncHistoryActionTypeHasMembers()
        {
            typeof(TraktSyncHistoryActionType).GetEnumNames().Should().HaveCount(4)
                                                             .And.Contain("Unspecified", "Scrobble", "Checkin", "Watch");
        }

        [TestMethod]
        public void TestTraktSyncHistoryActionTypeGetAsString()
        {
            TraktSyncHistoryActionType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncHistoryActionType.Scrobble.AsString().Should().Be("scrobble");
            TraktSyncHistoryActionType.Checkin.AsString().Should().Be("checkin");
            TraktSyncHistoryActionType.Watch.AsString().Should().Be("watch");
        }
    }
}
