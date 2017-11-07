namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaAudio_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaAudio>))]
            public TraktMediaAudio Value { get; set; }
        }

        [Fact]
        public void Test_TraktMediaAudio_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaAudio>();

            allValues.Should().NotBeNull().And.HaveCount(14);
            allValues.Should().Contain(new List<TraktMediaAudio>() { TraktMediaAudio.Unspecified, TraktMediaAudio.LPCM,
                                                                     TraktMediaAudio.MP3, TraktMediaAudio.AAC,
                                                                     TraktMediaAudio.OGG, TraktMediaAudio.WMA,
                                                                     TraktMediaAudio.DTS, TraktMediaAudio.DTS_MA,
                                                                     TraktMediaAudio.DTS_X, TraktMediaAudio.DolbyPrologic,
                                                                     TraktMediaAudio.DolbyDigital, TraktMediaAudio.DolbyDigitalPlus,
                                                                     TraktMediaAudio.DolbyTrueHD, TraktMediaAudio.DolbyAtmos });
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_LPCM()
        {
            var obj = new TestObject { Value = TraktMediaAudio.LPCM };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.LPCM);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_MP3()
        {
            var obj = new TestObject { Value = TraktMediaAudio.MP3 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.MP3);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_AAC()
        {
            var obj = new TestObject { Value = TraktMediaAudio.AAC };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.AAC);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_OGG()
        {
            var obj = new TestObject { Value = TraktMediaAudio.OGG };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.OGG);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_WMA()
        {
            var obj = new TestObject { Value = TraktMediaAudio.WMA };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.WMA);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DTS()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DTS };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DTS);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DTS_MA()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DTS_MA };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DTS_MA);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DTS_X()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DTS_X };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DTS_X);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DolbyPrologic()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyPrologic };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyPrologic);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DolbyDigital()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyDigital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyDigital);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DolbyDigitalPlus()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyDigitalPlus };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyDigitalPlus);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DolbyTrueHD()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyTrueHD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyTrueHD);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_DolbyAtmos()
        {
            var obj = new TestObject { Value = TraktMediaAudio.DolbyAtmos };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudio.DolbyAtmos);
        }

        [Fact]
        public void Test_TraktMediaAudio_WriteAndReadJson_Unspecified()
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
