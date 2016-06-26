namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktAccessTokenTypeConverter))]
            public TraktAccessTokenType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeHasMembers()
        {
            typeof(TraktAccessTokenType).GetEnumNames().Should().HaveCount(2)
                                                       .And.Contain("Bearer", "Unspecified");
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeGetAsString()
        {
            TraktAccessTokenType.Bearer.AsString().Should().Be("bearer");
            TraktAccessTokenType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeWriteAndReadJson_Bearer()
        {
            var obj = new TestObject { Value = TraktAccessTokenType.Bearer };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenType.Bearer);
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktAccessTokenType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenType.Unspecified);
        }
    }
}
