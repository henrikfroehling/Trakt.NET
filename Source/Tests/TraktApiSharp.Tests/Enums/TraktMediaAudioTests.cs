namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaAudioTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaAudio>))]
            public TraktMediaAudio Value { get; set; }
        }

        [TestMethod]
        public void TestTraktMediaAudioIsTraktEnumeration()
        {
            var enumeration = new TraktMediaAudio();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktMediaAudioGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaAudio>();

            allValues.Should().NotBeNull().And.HaveCount(12);
            allValues.Should().Contain(new List<TraktMediaAudio>() { TraktMediaAudio.Unspecified, TraktMediaAudio.LPCM,
                                                                     TraktMediaAudio.MP3, TraktMediaAudio.AAC,
                                                                     TraktMediaAudio.OGG, TraktMediaAudio.WMA,
                                                                     TraktMediaAudio.DTS, TraktMediaAudio.DTS_MA,
                                                                     TraktMediaAudio.DolbyPrologic, TraktMediaAudio.DolbyDigital,
                                                                     TraktMediaAudio.DolbyDigitalPlus, TraktMediaAudio.DolbyTrueHD });
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_LPCM()
        {
            var obj = new TestObject { Value = TraktMediaAudio.LPCM };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.LPCM);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_MP3()
        {
            var obj = new TestObject { Value = TraktMediaAudio.MP3 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.MP3);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_AAC()
        {
            var obj = new TestObject { Value = TraktMediaAudio.AAC };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.AAC);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_OGG()
        {
            var obj = new TestObject { Value = TraktMediaAudio.OGG };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.OGG);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_WMA()
        {
            var obj = new TestObject { Value = TraktMediaAudio.WMA };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.WMA);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DTS()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DTS };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DTS);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DTS_MA()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DTS_MA };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DTS_MA);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DolbyPrologic()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyPrologic };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyPrologic);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DolbyDigital()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyDigital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyDigital);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DolbyDigitalPlus()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyDigitalPlus };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyDigitalPlus);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_DolbyTrueHD()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyTrueHD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyTrueHD);
        }

        [TestMethod]
        public void TestTraktMediaAudioWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktMediaAudio.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.Unspecified);
        }
    }
}
