namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncRatingsItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSyncRatingsItemTypeConverter))]
            public TraktSyncRatingsItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeHasMembers()
        {
            typeof(TraktSyncRatingsItemType).GetEnumNames().Should().HaveCount(6)
                                                           .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode", "All");
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeGetAsString()
        {
            TraktSyncRatingsItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncRatingsItemType.All.AsString().Should().Be("all");
            TraktSyncRatingsItemType.Movie.AsString().Should().Be("movie");
            TraktSyncRatingsItemType.Show.AsString().Should().Be("show");
            TraktSyncRatingsItemType.Season.AsString().Should().Be("season");
            TraktSyncRatingsItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeGetAsStringUriParameter()
        {
            TraktSyncRatingsItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncRatingsItemType.All.AsStringUriParameter().Should().Be("all");
            TraktSyncRatingsItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncRatingsItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncRatingsItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncRatingsItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_All()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.All };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.All);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Show);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Season);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncRatingsItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncRatingsItemType.Unspecified);
        }
    }
}
