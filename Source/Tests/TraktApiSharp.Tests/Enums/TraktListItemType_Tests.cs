namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktListItemType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktListItemType>))]
            public TraktListItemType Value { get; set; }
        }

        [Fact]
        public void Test_TraktListItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktListItemType>() { TraktListItemType.Unspecified, TraktListItemType.Movie,
                                                                       TraktListItemType.Show, TraktListItemType.Season,
                                                                       TraktListItemType.Episode, TraktListItemType.Person });
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktListItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Movie);
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktListItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Show);
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktListItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Season);
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktListItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Episode);
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Person()
        {
            var obj = new TestObject { Value = TraktListItemType.Person };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Person);
        }

        [Fact]
        public void Test_TraktListItemType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktListItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Unspecified);
        }
    }
}
