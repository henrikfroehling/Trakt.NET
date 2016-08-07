namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktGenreTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktGenreTypeConverter))]
            public TraktGenreType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktGenreTypeIsTraktEnumeration()
        {
            var enumeration = new TraktGenreType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktGenreTypeWriteAndReadJson_Shows()
        {
            var obj = new TestObject { Value = TraktGenreType.Shows };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Shows);
        }

        [TestMethod]
        public void TestTraktGenreTypeWriteAndReadJson_Movies()
        {
            var obj = new TestObject { Value = TraktGenreType.Movies };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Movies);
        }

        [TestMethod]
        public void TestTraktGenreTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktGenreType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Unspecified);
        }
    }
}
