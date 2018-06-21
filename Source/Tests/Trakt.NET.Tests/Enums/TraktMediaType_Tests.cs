namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaType>))]
            public TraktMediaType Value { get; set; }
        }

        [Fact]
        public void Test_TraktMediaType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaType>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaType>() { TraktMediaType.Unspecified, TraktMediaType.Digital,
                                                                    TraktMediaType.Bluray, TraktMediaType.HD_DVD,
                                                                    TraktMediaType.DVD, TraktMediaType.VCD,
                                                                    TraktMediaType.VHS, TraktMediaType.BetaMax,
                                                                    TraktMediaType.LaserDisc });
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_Digital()
        {
            var obj = new TestObject { Value = TraktMediaType.Digital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.Digital);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_Bluray()
        {
            var obj = new TestObject { Value = TraktMediaType.Bluray };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.Bluray);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_HD_DVD()
        {
            var obj = new TestObject { Value = TraktMediaType.HD_DVD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.HD_DVD);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_DVD()
        {
            var obj = new TestObject { Value = TraktMediaType.DVD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.DVD);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_VCD()
        {
            var obj = new TestObject { Value = TraktMediaType.VCD };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.VCD);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_VHS()
        {
            var obj = new TestObject { Value = TraktMediaType.VHS };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.VHS);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_BetaMax()
        {
            var obj = new TestObject { Value = TraktMediaType.BetaMax };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.BetaMax);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_LaserDisc()
        {
            var obj = new TestObject { Value = TraktMediaType.LaserDisc };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktMediaType.LaserDisc);
        }

        [Fact]
        public void Test_TraktMediaType_WriteAndReadJson_Unspecified()
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
