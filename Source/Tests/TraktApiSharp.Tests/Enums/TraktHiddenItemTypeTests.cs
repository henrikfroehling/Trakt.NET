namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHiddenItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktHiddenItemType>))]
            public TraktHiddenItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeIsTraktEnumeration()
        {
            var enumeration = new TraktHiddenItemType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHiddenItemType>() { TraktHiddenItemType.Unspecified, TraktHiddenItemType.Movie,
                                                                         TraktHiddenItemType.Show, TraktHiddenItemType.Season });
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Movie);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Show);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Season);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Unspecified);
        }
    }
}
