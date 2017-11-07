namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktReleaseType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktReleaseType>))]
            public TraktReleaseType Value { get; set; }
        }

        [Fact]
        public void Test_TraktReleaseType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktReleaseType>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktReleaseType>() { TraktReleaseType.Unspecified, TraktReleaseType.Unknown,
                                                                      TraktReleaseType.Premiere, TraktReleaseType.Limited,
                                                                      TraktReleaseType.Theatrical, TraktReleaseType.Digital,
                                                                      TraktReleaseType.Physical, TraktReleaseType.TV });
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Premiere()
        {
            var obj = new TestObject { Value = TraktReleaseType.Premiere };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Premiere);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Limited()
        {
            var obj = new TestObject { Value = TraktReleaseType.Limited };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Limited);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Theatrical()
        {
            var obj = new TestObject { Value = TraktReleaseType.Theatrical };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Theatrical);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Digital()
        {
            var obj = new TestObject { Value = TraktReleaseType.Digital };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Digital);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Physical()
        {
            var obj = new TestObject { Value = TraktReleaseType.Physical };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Physical);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Tv()
        {
            var obj = new TestObject { Value = TraktReleaseType.TV };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.TV);
        }

        [Fact]
        public void Test_TraktReleaseType_WriteAndReadJson_Unknown()
        {
            var obj = new TestObject { Value = TraktReleaseType.Unknown };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktReleaseType.Unknown);
        }
    }
}
