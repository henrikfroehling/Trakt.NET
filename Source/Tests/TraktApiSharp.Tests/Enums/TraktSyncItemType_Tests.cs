namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSyncItemType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncItemType>))]
            public TraktSyncItemType Value { get; set; }
        }

        [Fact]
        public void Test_TraktSyncItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncItemType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktSyncItemType>() { TraktSyncItemType.Unspecified, TraktSyncItemType.Movie,
                                                                       TraktSyncItemType.Show, TraktSyncItemType.Season,
                                                                       TraktSyncItemType.Episode });
        }

        [Fact]
        public void Test_TraktSyncItemType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Movie);
        }

        [Fact]
        public void Test_TraktSyncItemType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Show);
        }

        [Fact]
        public void Test_TraktSyncItemType_WriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Season);
        }

        [Fact]
        public void Test_TraktSyncItemType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Episode);
        }

        [Fact]
        public void Test_TraktSyncItemType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Unspecified);
        }
    }
}
