namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktObjectTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktObjectType>))]
            public TraktObjectType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktObjectTypeIsTraktEnumeration()
        {
            var enumeration = new TraktObjectType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktObjectTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktObjectType>() { TraktObjectType.Unspecified, TraktObjectType.Movie,
                                                                     TraktObjectType.Show, TraktObjectType.Season,
                                                                     TraktObjectType.Episode, TraktObjectType.List,
                                                                     TraktObjectType.All });
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktObjectType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Movie);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktObjectType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Show);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktObjectType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Season);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktObjectType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Episode);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktObjectType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.List);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktObjectType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.All);
        }

        [TestMethod]
        public void TestTraktObjectTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktObjectType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Unspecified);
        }
    }
}
