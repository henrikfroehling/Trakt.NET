namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSyncType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncType>))]
            public TraktSyncType Value { get; set; }
        }

        [Fact]
        public void Test_TraktSyncType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktSyncType>() { TraktSyncType.Unspecified, TraktSyncType.Movie,
                                                                   TraktSyncType.Episode });
        }

        [Fact]
        public void Test_TraktSyncType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Movie);
        }

        [Fact]
        public void Test_TraktSyncType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Episode);
        }

        [Fact]
        public void Test_TraktSyncType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Unspecified);
        }
    }
}
