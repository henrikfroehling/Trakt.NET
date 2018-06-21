namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaAudioChannel_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaAudioChannel>))]
            public TraktMediaAudioChannel Value { get; set; }
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaAudioChannel>();

            allValues.Should().NotBeNull().And.HaveCount(12);
            allValues.Should().Contain(new List<TraktMediaAudioChannel>() { TraktMediaAudioChannel.Unspecified, TraktMediaAudioChannel.Channels_1_0,
                                                                            TraktMediaAudioChannel.Channels_2_0, TraktMediaAudioChannel.Channels_2_1,
                                                                            TraktMediaAudioChannel.Channels_3_0, TraktMediaAudioChannel.Channels_3_1,
                                                                            TraktMediaAudioChannel.Channels_4_0, TraktMediaAudioChannel.Channels_4_1,
                                                                            TraktMediaAudioChannel.Channels_5_0, TraktMediaAudioChannel.Channels_5_1,
                                                                            TraktMediaAudioChannel.Channels_6_1, TraktMediaAudioChannel.Channels_7_1 });
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_1_0()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_1_0 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_1_0);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_2_0()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_2_0 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_2_0);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_2_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_2_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_2_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_3_0()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_3_0 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_3_0);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_3_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_3_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_3_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_4_0()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_4_0 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_4_0);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_4_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_4_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_4_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_5_0()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_5_0 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_5_0);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_5_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_5_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_5_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_6_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_6_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_6_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Channels_7_1()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Channels_7_1 };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Channels_7_1);
        }

        [Fact]
        public void Test_TraktMediaAudioChannel_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktMediaAudioChannel.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaAudioChannel.Unspecified);
        }
    }
}
