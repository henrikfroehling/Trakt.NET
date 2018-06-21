namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktRatingsItemType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktRatingsItemType>))]
            public TraktRatingsItemType Value { get; set; }
        }

        [Fact]
        public void Test_TraktRatingsItemTyp_eGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktRatingsItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktRatingsItemType>() { TraktRatingsItemType.Unspecified,
                                                                          TraktRatingsItemType.Movie,
                                                                          TraktRatingsItemType.Show,
                                                                          TraktRatingsItemType.Season,
                                                                          TraktRatingsItemType.Episode,
                                                                          TraktRatingsItemType.All });
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.All);
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Movie);
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Show);
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Season);
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Episode);
        }

        [Fact]
        public void Test_TraktRatingsItemType_WriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktRatingsItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktRatingsItemType.Unspecified);
        }
    }
}
