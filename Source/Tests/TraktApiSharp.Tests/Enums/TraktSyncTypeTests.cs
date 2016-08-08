namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncType>))]
            public TraktSyncType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSyncType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSyncTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktSyncType>() { TraktSyncType.Unspecified, TraktSyncType.Movie,
                                                                   TraktSyncType.Episode });
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Unspecified()
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
