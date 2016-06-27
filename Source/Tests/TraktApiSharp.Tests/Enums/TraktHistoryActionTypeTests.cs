namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHistoryActionTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktHistoryActionTypeConverter))]
            public TraktHistoryActionType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeHasMembers()
        {
            typeof(TraktHistoryActionType).GetEnumNames().Should().HaveCount(4)
                                                         .And.Contain("Unspecified", "Scrobble", "Checkin", "Watch");
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeGetAsString()
        {
            TraktHistoryActionType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktHistoryActionType.Scrobble.AsString().Should().Be("scrobble");
            TraktHistoryActionType.Checkin.AsString().Should().Be("checkin");
            TraktHistoryActionType.Watch.AsString().Should().Be("watch");
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeWriteAndReadJson_Scrobble()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Scrobble };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Scrobble);
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeWriteAndReadJson_Checkin()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Checkin };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Checkin);
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeWriteAndReadJson_Watch()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Watch };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Watch);
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Unspecified);
        }
    }
}
