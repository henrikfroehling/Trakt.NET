namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncRatingsItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncRatingsItemType>))]
            public TraktSyncRatingsItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSyncRatingsItemType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncRatingsItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSyncRatingsItemType>() { TraktSyncRatingsItemType.Unspecified,
                                                                              TraktSyncRatingsItemType.Movie,
                                                                              TraktSyncRatingsItemType.Show,
                                                                              TraktSyncRatingsItemType.Season,
                                                                              TraktSyncRatingsItemType.Episode,
                                                                              TraktSyncRatingsItemType.All });
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.All);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Show);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Season);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Unspecified);
        }
    }
}
