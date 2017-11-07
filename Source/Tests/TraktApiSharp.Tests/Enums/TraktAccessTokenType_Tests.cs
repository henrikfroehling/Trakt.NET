namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktAccessTokenType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessTokenType>))]
            public TraktAccessTokenType Value { get; set; }
        }

        [Fact]
        public void Test_TraktAccessTokenType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenType>();

            allValues.Should().NotBeNull().And.HaveCount(2);
            allValues.Should().Contain(new List<TraktAccessTokenType>() { TraktAccessTokenType.Unspecified, TraktAccessTokenType.Bearer });
        }

        [Fact]
        public void Test_TraktAccessTokenType_WriteAndReadJson_Bearer()
        {
            var obj = new TestObject { Value = TraktAccessTokenType.Bearer };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenType.Bearer);
        }

        [Fact]
        public void Test_TraktAccessTokenType_WriteAndReadJson_Unspecified()
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
