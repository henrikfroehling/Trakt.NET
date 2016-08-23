namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktUserLikeTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktUserLikeType>))]
            public TraktUserLikeType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktUserLikeTypeIsTraktEnumeration()
        {
            var enumeration = new TraktUserLikeType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktUserLikeTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktUserLikeType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktUserLikeType>() { TraktUserLikeType.Unspecified, TraktUserLikeType.Comment,
                                                                       TraktUserLikeType.List });
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_Comment()
        {
            var obj = new TestObject { Value = TraktUserLikeType.Comment };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.Comment);
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktUserLikeType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.List);
        }

        [TestMethod]
        public void TestTraktUserLikeTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktUserLikeType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.Unspecified);
        }
    }
}
