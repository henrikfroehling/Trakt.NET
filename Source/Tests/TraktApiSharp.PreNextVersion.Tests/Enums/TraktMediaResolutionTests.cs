namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaResolutionTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaResolution>))]
            public TraktMediaResolution Value { get; set; }
        }

        [TestMethod]
        public void TestTraktMediaResolutionIsTraktEnumeration()
        {
            var enumeration = new TraktMediaResolution();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktMediaResolutionGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaResolution>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaResolution>() { TraktMediaResolution.Unspecified, TraktMediaResolution.UHD_4k,
                                                                          TraktMediaResolution.HD_1080p, TraktMediaResolution.HD_1080i,
                                                                          TraktMediaResolution.HD_720p, TraktMediaResolution.SD_480p,
                                                                          TraktMediaResolution.SD_480i, TraktMediaResolution.SD_576p,
                                                                          TraktMediaResolution.SD_576i });
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_UHD_4k()
        {
            var obj = new TestObject { Value = TraktMediaResolution.UHD_4k };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.UHD_4k);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_HD_1080p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_1080p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_1080p);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_HD_1080i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_1080i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_1080i);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_HD_720p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_720p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_720p);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_SD_480p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_480p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_480p);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_SD_480i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_480i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_480i);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_SD_576p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_576p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_576p);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_SD_576i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_576i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_576i);
        }

        [TestMethod]
        public void TestTraktMediaResolutionWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktMediaResolution.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.Unspecified);
        }
    }
}
