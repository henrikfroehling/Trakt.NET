namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktReleaseTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktReleaseType>))]
            public TraktReleaseType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktReleaseTypeIsTraktEnumeration()
        {
            var enumeration = new TraktReleaseType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktReleaseTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktReleaseType>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktReleaseType>() { TraktReleaseType.Unspecified, TraktReleaseType.Unknown,
                                                                      TraktReleaseType.Premiere, TraktReleaseType.Limited,
                                                                      TraktReleaseType.Theatrical, TraktReleaseType.Digital,
                                                                      TraktReleaseType.Physical, TraktReleaseType.TV });
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Premiere()
        {
            var obj = new TestObject { Value = TraktReleaseType.Premiere };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Premiere);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Limited()
        {
            var obj = new TestObject { Value = TraktReleaseType.Limited };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Limited);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Theatrical()
        {
            var obj = new TestObject { Value = TraktReleaseType.Theatrical };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Theatrical);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Digital()
        {
            var obj = new TestObject { Value = TraktReleaseType.Digital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Digital);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Physical()
        {
            var obj = new TestObject { Value = TraktReleaseType.Physical };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Physical);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Tv()
        {
            var obj = new TestObject { Value = TraktReleaseType.TV };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.TV);
        }

        [TestMethod]
        public void TestTraktReleaseTypeWriteAndReadJson_Unknown()
        {
            var obj = new TestObject { Value = TraktReleaseType.Unknown };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Unknown);
        }
    }
}
