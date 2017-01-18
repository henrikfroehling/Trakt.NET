namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchIdLookupTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSearchIdLookupType>))]
            public TraktSearchIdLookupType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSearchIdLookupType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchIdLookupType>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktSearchIdLookupType>() { TraktSearchIdLookupType.Unspecified, TraktSearchIdLookupType.TraktMovie,
                                                                             TraktSearchIdLookupType.TraktShow, TraktSearchIdLookupType.TraktEpisode,
                                                                             TraktSearchIdLookupType.ImDB, TraktSearchIdLookupType.TmDB,
                                                                             TraktSearchIdLookupType.TvDB, TraktSearchIdLookupType.TVRage });
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktMovie()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktMovie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktMovie);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktShow()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktShow };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktShow);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktEpisode()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktEpisode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktEpisode);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_ImDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.ImDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.ImDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TmDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TmDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TmDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TvDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TvDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TvDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TVRage()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TVRage };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TVRage);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.Unspecified);
        }
    }
}
