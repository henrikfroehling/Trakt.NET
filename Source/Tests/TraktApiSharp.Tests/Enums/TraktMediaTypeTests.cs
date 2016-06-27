namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktMediaTypeConverter))]
            public TraktMediaType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktMediaTypeHasMembers()
        {
            typeof(TraktMediaType).GetEnumNames().Should().HaveCount(9)
                                                 .And.Contain("Unspecified", "Digital", "Bluray", "HD_DVD", "DVD", "VCD", "VHS", "BetaMax", "LaserDisc");
        }

        [TestMethod]
        public void TestTraktMediaTypeGetAsString()
        {
            TraktMediaType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaType.Digital.AsString().Should().Be("digital");
            TraktMediaType.Bluray.AsString().Should().Be("bluray");
            TraktMediaType.HD_DVD.AsString().Should().Be("hddvd");
            TraktMediaType.DVD.AsString().Should().Be("dvd");
            TraktMediaType.VCD.AsString().Should().Be("vcd");
            TraktMediaType.VHS.AsString().Should().Be("vhs");
            TraktMediaType.BetaMax.AsString().Should().Be("betamax");
            TraktMediaType.LaserDisc.AsString().Should().Be("laserdisc");
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
