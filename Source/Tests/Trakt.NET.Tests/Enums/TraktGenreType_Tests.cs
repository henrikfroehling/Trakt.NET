namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktGenreType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktGenreType>))]
            public TraktGenreType Value { get; set; }
        }

        [Fact]
        public void Test_TraktGenreType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktGenreType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktGenreType>() { TraktGenreType.Unspecified, TraktGenreType.Shows,
                                                                    TraktGenreType.Movies });
        }

        [Fact]
        public void Test_TraktGenreType_WriteAndReadJson_Shows()
        {
            var obj = new TestObject { Value = TraktGenreType.Shows };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Shows);
        }

        [Fact]
        public void Test_TraktGenreType_WriteAndReadJson_Movies()
        {
            var obj = new TestObject { Value = TraktGenreType.Movies };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Movies);
        }

        [Fact]
        public void Test_TraktGenreType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktGenreType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktGenreType.Unspecified);
        }
    }
}
