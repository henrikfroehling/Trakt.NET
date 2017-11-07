namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktAccessTokenGrantType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessTokenGrantType>))]
            public TraktAccessTokenGrantType Value { get; set; }
        }

        [Fact]
        public void Test_TraktAccessTokenGrantType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessTokenGrantType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktAccessTokenGrantType>() { TraktAccessTokenGrantType.Unspecified,
                                                                               TraktAccessTokenGrantType.AuthorizationCode,
                                                                               TraktAccessTokenGrantType.RefreshToken });
        }

        [Fact]
        public void Test_TraktAccessTokenGrantType_WriteAndReadJson_AuthorizationCode()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.AuthorizationCode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.AuthorizationCode);
        }

        [Fact]
        public void Test_TraktAccessTokenGrantType_WriteAndReadJson_RefreshToken()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.RefreshToken };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.RefreshToken);
        }

        [Fact]
        public void Test_TraktAccessTokenGrantType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktAccessTokenGrantType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessTokenGrantType.Unspecified);
        }
    }
}
