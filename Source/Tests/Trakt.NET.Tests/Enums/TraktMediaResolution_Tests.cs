namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaResolution_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaResolution>))]
            public TraktMediaResolution Value { get; set; }
        }

        [Fact]
        public void Test_TraktMediaResolution_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaResolution>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaResolution>() { TraktMediaResolution.Unspecified, TraktMediaResolution.UHD_4k,
                                                                          TraktMediaResolution.HD_1080p, TraktMediaResolution.HD_1080i,
                                                                          TraktMediaResolution.HD_720p, TraktMediaResolution.SD_480p,
                                                                          TraktMediaResolution.SD_480i, TraktMediaResolution.SD_576p,
                                                                          TraktMediaResolution.SD_576i });
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_UHD_4k()
        {
            var obj = new TestObject { Value = TraktMediaResolution.UHD_4k };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.UHD_4k);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_HD_1080p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_1080p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_1080p);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_HD_1080i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_1080i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_1080i);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_HD_720p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.HD_720p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.HD_720p);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_SD_480p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_480p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_480p);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_SD_480i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_480i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_480i);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_SD_576p()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_576p };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_576p);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_SD_576i()
        {
            var obj = new TestObject { Value = TraktMediaResolution.SD_576i };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaResolution.SD_576i);
        }

        [Fact]
        public void Test_TraktMediaResolution_WriteAndReadJson_Unspecified()
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
