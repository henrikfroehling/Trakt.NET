namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktUserLikeType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktUserLikeType>))]
            public TraktUserLikeType Value { get; set; }
        }

        [Fact]
        public void Test_TraktUserLikeType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktUserLikeType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktUserLikeType>() { TraktUserLikeType.Unspecified, TraktUserLikeType.Comment,
                                                                       TraktUserLikeType.List });
        }

        [Fact]
        public void Test_TraktUserLikeType_WriteAndReadJson_Comment()
        {
            var obj = new TestObject { Value = TraktUserLikeType.Comment };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.Comment);
        }

        [Fact]
        public void Test_TraktUserLikeType_WriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktUserLikeType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktUserLikeType.List);
        }

        [Fact]
        public void Test_TraktUserLikeType_WriteAndReadJson_Unspecified()
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
