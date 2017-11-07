namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktShowStatus_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktShowStatus>))]
            public TraktShowStatus Value { get; set; }
        }

        [Fact]
        public void Test_TraktShowStatus_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktShowStatus>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktShowStatus>() { TraktShowStatus.Unspecified, TraktShowStatus.ReturningSeries,
                                                                     TraktShowStatus.InProduction, TraktShowStatus.Canceled,
                                                                     TraktShowStatus.Ended });
        }

        [Fact]
        public void Test_TraktShowStatus_WriteAndReadJson_ReturningSeries()
        {
            var obj = new TestObject { Value = TraktShowStatus.ReturningSeries };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.ReturningSeries);
        }

        [Fact]
        public void Test_TraktShowStatus_WriteAndReadJson_InProduction()
        {
            var obj = new TestObject { Value = TraktShowStatus.InProduction };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.InProduction);
        }

        [Fact]
        public void Test_TraktShowStatus_WriteAndReadJson_Canceled()
        {
            var obj = new TestObject { Value = TraktShowStatus.Canceled };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.Canceled);
        }

        [Fact]
        public void Test_TraktShowStatus_WriteAndReadJson_Ended()
        {
            var obj = new TestObject { Value = TraktShowStatus.Ended };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktShowStatus.Ended);
        }

        [Fact]
        public void Test_TraktShowStatus_WriteAndReadJson_Unspecified()
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
