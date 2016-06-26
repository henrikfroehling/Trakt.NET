namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaResolutionTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktMediaResolutionConverter))]
            public TraktMediaResolution Value { get; set; }
        }

        [TestMethod]
        public void TestTraktMediaResolutionHasMembers()
        {
            typeof(TraktMediaResolution).GetEnumNames().Should().HaveCount(9)
                                                       .And.Contain("Unspecified", "UHD_4k", "HD_1080p", "HD_1080i", "HD_720p",
                                                                    "SD_480p", "SD_480i", "SD_576p", "SD_576i");
        }

        [TestMethod]
        public void TestTraktMediaResolutionGetAsString()
        {
            TraktMediaResolution.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaResolution.UHD_4k.AsString().Should().Be("uhd_4k");
            TraktMediaResolution.HD_1080p.AsString().Should().Be("hd_1080p");
            TraktMediaResolution.HD_1080i.AsString().Should().Be("hd_1080i");
            TraktMediaResolution.HD_720p.AsString().Should().Be("hd_720p");
            TraktMediaResolution.SD_480p.AsString().Should().Be("sd_480p");
            TraktMediaResolution.SD_480i.AsString().Should().Be("sd_480i");
            TraktMediaResolution.SD_576p.AsString().Should().Be("sd_576p");
            TraktMediaResolution.SD_576i.AsString().Should().Be("sd_576i");
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
