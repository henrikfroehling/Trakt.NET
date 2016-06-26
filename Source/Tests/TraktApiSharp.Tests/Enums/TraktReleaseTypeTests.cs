namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktReleaseTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktReleaseTypeConverter))]
            public TraktReleaseType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktReleaseTypeHasMembers()
        {
            typeof(TraktReleaseType).GetEnumNames().Should().HaveCount(7)
                                                   .And.Contain("Unknown", "Premiere", "Limited", "Theatrical", "Digital", "Physical", "Tv");
        }

        [TestMethod]
        public void TestTraktReleaseTypeGetAsString()
        {
            TraktReleaseType.Unknown.AsString().Should().Be("unknown");
            TraktReleaseType.Premiere.AsString().Should().Be("premiere");
            TraktReleaseType.Limited.AsString().Should().Be("limited");
            TraktReleaseType.Theatrical.AsString().Should().Be("theatrical");
            TraktReleaseType.Digital.AsString().Should().Be("digital");
            TraktReleaseType.Physical.AsString().Should().Be("physical");
            TraktReleaseType.Tv.AsString().Should().Be("tv");
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
            var obj = new TestObject { Value = TraktReleaseType.Tv };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Tv);
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
