namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHistoryActionTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktHistoryActionType>))]
            public TraktHistoryActionType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeIsTraktEnumeration()
        {
            var enumeration = new TraktHistoryActionType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktHistoryActionTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHistoryActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHistoryActionType>() { TraktHistoryActionType.Unspecified, TraktHistoryActionType.Scrobble,
                                                                            TraktHistoryActionType.Checkin, TraktHistoryActionType.Watch });
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
