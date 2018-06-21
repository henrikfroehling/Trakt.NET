namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktAccessScope_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
            public TraktAccessScope Value { get; set; }
        }

        [Fact]
        public void Test_TraktAccessScope_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktAccessScope>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktAccessScope>() { TraktAccessScope.Unspecified, TraktAccessScope.Private,
                                                                      TraktAccessScope.Public, TraktAccessScope.Friends });
        }

        [Fact]
        public void Test_TraktAccessScope_WriteAndReadJson_Friends()
        {
            var obj = new TestObject { Value = TraktAccessScope.Friends };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Friends);
        }

        [Fact]
        public void Test_TraktAccessScope_WriteAndReadJson_Private()
        {
            var obj = new TestObject { Value = TraktAccessScope.Private };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Private);
        }

        [Fact]
        public void Test_TraktAccessScope_WriteAndReadJson_Public()
        {
            var obj = new TestObject { Value = TraktAccessScope.Public };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktAccessScope.Public);
        }

        [Fact]
        public void Test_TraktAccessScope_WriteAndReadJson_Unspecified()
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
