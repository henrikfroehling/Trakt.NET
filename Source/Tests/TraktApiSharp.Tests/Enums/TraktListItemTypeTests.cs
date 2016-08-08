namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktListItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktListItemType>))]
            public TraktListItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktListItemTypeIsTraktEnumeration()
        {
            var enumeration = new TraktListItemType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktListItemTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktListItemType>() { TraktListItemType.Unspecified, TraktListItemType.Movie,
                                                                       TraktListItemType.Show, TraktListItemType.Season,
                                                                       TraktListItemType.Episode, TraktListItemType.Person });
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktListItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Movie);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktListItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Show);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktListItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Season);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktListItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Episode);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Person()
        {
            var obj = new TestObject { Value = TraktListItemType.Person };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Person);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktListItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Unspecified);
        }
    }
}
