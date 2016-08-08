namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncItemType>))]
            public TraktSyncItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncItemTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSyncItemType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSyncItemTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncItemType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktSyncItemType>() { TraktSyncItemType.Unspecified, TraktSyncItemType.Movie,
                                                                       TraktSyncItemType.Show, TraktSyncItemType.Season,
                                                                       TraktSyncItemType.Episode });
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Show);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Season);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Unspecified()
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
