namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaType>))]
            public TraktMediaType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktMediaTypeIsTraktEnumeration()
        {
            var enumeration = new TraktMediaType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktMediaTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaType>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaType>() { TraktMediaType.Unspecified, TraktMediaType.Digital,
                                                                    TraktMediaType.Bluray, TraktMediaType.HD_DVD,
                                                                    TraktMediaType.DVD, TraktMediaType.VCD,
                                                                    TraktMediaType.VHS, TraktMediaType.BetaMax,
                                                                    TraktMediaType.LaserDisc });
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_Digital()
        {
            var obj = new TestObject { Value = TraktMediaType.Digital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.Digital);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_Bluray()
        {
            var obj = new TestObject { Value = TraktMediaType.Bluray };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.Bluray);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_HD_DVD()
        {
            var obj = new TestObject { Value = TraktMediaType.HD_DVD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.HD_DVD);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_DVD()
        {
            var obj = new TestObject { Value = TraktMediaType.DVD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.DVD);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_VCD()
        {
            var obj = new TestObject { Value = TraktMediaType.VCD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.VCD);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_VHS()
        {
            var obj = new TestObject { Value = TraktMediaType.VHS };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.VHS);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_BetaMax()
        {
            var obj = new TestObject { Value = TraktMediaType.BetaMax };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.BetaMax);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_LaserDisc()
        {
            var obj = new TestObject { Value = TraktMediaType.LaserDisc };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.LaserDisc);
        }

        [TestMethod]
        public void TestTraktMediaTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktMediaType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.Unspecified);
        }
    }
}
