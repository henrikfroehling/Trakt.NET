namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktHistoryActionType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktHistoryActionType>))]
            public TraktHistoryActionType Value { get; set; }
        }

        [Fact]
        public void Test_TraktHistoryActionType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHistoryActionType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHistoryActionType>() { TraktHistoryActionType.Unspecified, TraktHistoryActionType.Scrobble,
                                                                            TraktHistoryActionType.Checkin, TraktHistoryActionType.Watch });
        }

        [Fact]
        public void Test_TraktHistoryActionType_WriteAndReadJson_Scrobble()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Scrobble };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Scrobble);
        }

        [Fact]
        public void Test_TraktHistoryActionType_WriteAndReadJson_Checkin()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Checkin };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Checkin);
        }

        [Fact]
        public void Test_TraktHistoryActionType_WriteAndReadJson_Watch()
        {
            var obj = new TestObject { Value = TraktHistoryActionType.Watch };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHistoryActionType.Watch);
        }

        [Fact]
        public void Test_TraktHistoryActionType_WriteAndReadJson_Unspecified()
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
