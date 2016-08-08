namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessScopeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
            public TraktAccessScope Value { get; set; }
        }

        [TestMethod]
        public void TestTraktAccessScopeIsTraktEnumeration()
        {
            var enumeration = new TraktAccessScope();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktAccessScopeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessScope>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktAccessScope>() { TraktAccessScope.Unspecified, TraktAccessScope.Private,
                                                                      TraktAccessScope.Public, TraktAccessScope.Friends });
        }

        [TestMethod]
        public void TestTraktAccessScopeWriteAndReadJson_Friends()
        {
            var obj = new TestObject { Value = TraktAccessScope.Friends };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Friends);
        }

        [TestMethod]
        public void TestTraktAccessScopeWriteAndReadJson_Private()
        {
            var obj = new TestObject { Value = TraktAccessScope.Private };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Private);
        }

        [TestMethod]
        public void TestTraktAccessScopeWriteAndReadJson_Public()
        {
            var obj = new TestObject { Value = TraktAccessScope.Public };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Public);
        }

        [TestMethod]
        public void TestTraktAccessScopeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktAccessScope.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Unspecified);
        }
    }
}
