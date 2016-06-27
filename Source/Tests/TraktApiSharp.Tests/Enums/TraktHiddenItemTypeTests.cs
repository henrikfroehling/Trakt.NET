namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHiddenItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktHiddenItemTypeConverter))]
            public TraktHiddenItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeHasMembers()
        {
            typeof(TraktHiddenItemType).GetEnumNames().Should().HaveCount(4)
                                                      .And.Contain("Movie", "Show", "Season", "Unspecified");
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeGetAsString()
        {
            TraktHiddenItemType.Movie.AsString().Should().Be("movie");
            TraktHiddenItemType.Show.AsString().Should().Be("show");
            TraktHiddenItemType.Season.AsString().Should().Be("season");
            TraktHiddenItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Movie);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Show);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktHiddenItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktHiddenItemType.Season);
        }

        [TestMethod]
        public void TestTraktHiddenItemTypeWriteAndReadJson_Unspecified()
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
