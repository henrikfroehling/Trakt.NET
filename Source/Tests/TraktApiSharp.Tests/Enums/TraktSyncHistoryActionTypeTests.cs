namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncHistoryActionTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSyncHistoryActionTypeConverter))]
            public TraktSyncHistoryActionType Value { get; set; }
        }

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

        [TestMethod]
        public void TestTraktSyncHistoryActionTypeWriteAndReadJson_Scrobble()
        {
            var obj = new TestObject { Value = TraktSyncHistoryActionType.Scrobble };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncHistoryActionType.Scrobble);
        }

        [TestMethod]
        public void TestTraktSyncHistoryActionTypeWriteAndReadJson_Checkin()
        {
            var obj = new TestObject { Value = TraktSyncHistoryActionType.Checkin };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncHistoryActionType.Checkin);
        }

        [TestMethod]
        public void TestTraktSyncHistoryActionTypeWriteAndReadJson_Watch()
        {
            var obj = new TestObject { Value = TraktSyncHistoryActionType.Watch };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncHistoryActionType.Watch);
        }

        [TestMethod]
        public void TestTraktSyncHistoryActionTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncHistoryActionType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncHistoryActionType.Unspecified);
        }
    }
}
