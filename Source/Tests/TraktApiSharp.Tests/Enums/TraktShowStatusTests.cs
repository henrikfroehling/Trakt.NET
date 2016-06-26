namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktShowStatusTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktShowStatusConverter))]
            public TraktShowStatus Value { get; set; }
        }

        [TestMethod]
        public void TestTraktShowStatusHasMembers()
        {
            typeof(TraktShowStatus).GetEnumNames().Should().HaveCount(5)
                                                  .And.Contain("Unspecified", "ReturningSeries", "InProduction", "Canceled", "Ended");
        }

        [TestMethod]
        public void TestTraktShowStatusGetAsString()
        {
            TraktShowStatus.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktShowStatus.ReturningSeries.AsString().Should().Be("returning series");
            TraktShowStatus.InProduction.AsString().Should().Be("in production");
            TraktShowStatus.Canceled.AsString().Should().Be("canceled");
            TraktShowStatus.Ended.AsString().Should().Be("ended");
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
