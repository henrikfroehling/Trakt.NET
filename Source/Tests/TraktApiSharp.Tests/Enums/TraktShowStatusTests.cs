namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktShowStatusTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktShowStatus>))]
            public TraktShowStatus Value { get; set; }
        }

        [TestMethod]
        public void TestTraktShowStatusIsTraktEnumeration()
        {
            var enumeration = new TraktShowStatus();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktShowStatusGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktShowStatus>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktShowStatus>() { TraktShowStatus.Unspecified, TraktShowStatus.ReturningSeries,
                                                                     TraktShowStatus.InProduction, TraktShowStatus.Canceled,
                                                                     TraktShowStatus.Ended });
        }

        [TestMethod]
        public void TestTraktShowStatusWriteAndReadJson_ReturningSeries()
        {
            var obj = new TestObject { Value = TraktShowStatus.ReturningSeries };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.ReturningSeries);
        }

        [TestMethod]
        public void TestTraktShowStatusWriteAndReadJson_InProduction()
        {
            var obj = new TestObject { Value = TraktShowStatus.InProduction };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.InProduction);
        }

        [TestMethod]
        public void TestTraktShowStatusWriteAndReadJson_Canceled()
        {
            var obj = new TestObject { Value = TraktShowStatus.Canceled };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.Canceled);
        }

        [TestMethod]
        public void TestTraktShowStatusWriteAndReadJson_Ended()
        {
            var obj = new TestObject { Value = TraktShowStatus.Ended };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.Ended);
        }

        [TestMethod]
        public void TestTraktShowStatusWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktShowStatus.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.Unspecified);
        }
    }
}
