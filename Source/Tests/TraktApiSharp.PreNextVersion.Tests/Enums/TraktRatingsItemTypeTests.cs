namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktRatingsItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktRatingsItemType>))]
            public TraktRatingsItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeIsTraktEnumeration()
        {
            var enumeration = new TraktRatingsItemType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktRatingsItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktRatingsItemType>() { TraktRatingsItemType.Unspecified,
                                                                          TraktRatingsItemType.Movie,
                                                                          TraktRatingsItemType.Show,
                                                                          TraktRatingsItemType.Season,
                                                                          TraktRatingsItemType.Episode,
                                                                          TraktRatingsItemType.All });
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.All);
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Movie);
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Show);
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Season);
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Episode);
        }

        [TestMethod]
        public void TestTraktRatingsItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Unspecified);
        }
    }
}
