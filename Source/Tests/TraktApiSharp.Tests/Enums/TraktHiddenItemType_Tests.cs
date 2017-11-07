namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktHiddenItemType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktHiddenItemType>))]
            public TraktHiddenItemType Value { get; set; }
        }

        [Fact]
        public void Test_TraktHiddenItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHiddenItemType>() { TraktHiddenItemType.Unspecified, TraktHiddenItemType.Movie,
                                                                         TraktHiddenItemType.Show, TraktHiddenItemType.Season });
        }

        [Fact]
        public void Test_TraktHiddenItemType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Movie);
        }

        [Fact]
        public void Test_TraktHiddenItemType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Show);
        }

        [Fact]
        public void Test_TraktHiddenItemType_WriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Season);
        }

        [Fact]
        public void Test_TraktHiddenItemType_WriteAndReadJson_Unspecified()
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
