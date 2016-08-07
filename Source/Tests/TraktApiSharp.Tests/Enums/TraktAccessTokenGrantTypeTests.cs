namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenGrantTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktAccessTokenGrantTypeConverter))]
            public TraktAccessTokenGrantType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktAccessTokenGrantTypeIsTraktEnumeration()
        {
            var enumeration = new TraktAccessTokenGrantType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktAccessTokenGrantTypeWriteAndReadJson_AuthorizationCode()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.AuthorizationCode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.AuthorizationCode);
        }

        [TestMethod]
        public void TestTraktAccessTokenGrantTypeWriteAndReadJson_RefreshToken()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.RefreshToken };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.RefreshToken);
        }

        [TestMethod]
        public void TestTraktAccessTokenGrantTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.Unspecified);
        }
    }
}
