namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessTokenType>))]
            public TraktAccessTokenType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeIsTraktEnumeration()
        {
            var enumeration = new TraktAccessTokenType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenType>();

            allValues.Should().NotBeNull().And.HaveCount(2);
            allValues.Should().Contain(new List<TraktAccessTokenType>() { TraktAccessTokenType.Unspecified, TraktAccessTokenType.Bearer });
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
