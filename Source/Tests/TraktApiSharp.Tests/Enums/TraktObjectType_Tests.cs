namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktObjectType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktObjectType>))]
            public TraktObjectType Value { get; set; }
        }

        [Fact]
        public void Test_TraktObjectType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktObjectType>() { TraktObjectType.Unspecified, TraktObjectType.Movie,
                                                                     TraktObjectType.Show, TraktObjectType.Season,
                                                                     TraktObjectType.Episode, TraktObjectType.List,
                                                                     TraktObjectType.All });
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktObjectType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Movie);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktObjectType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Show);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktObjectType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Season);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktObjectType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Episode);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktObjectType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.List);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktObjectType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.All);
        }

        [Fact]
        public void Test_TraktObjectType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktObjectType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktObjectType.Unspecified);
        }
    }
}
