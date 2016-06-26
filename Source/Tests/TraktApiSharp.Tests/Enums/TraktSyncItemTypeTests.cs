namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSyncItemTypeConverter))]
            public TraktSyncItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncItemTypeHasMembers()
        {
            typeof(TraktSyncItemType).GetEnumNames().Should().HaveCount(5)
                                                           .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncItemTypeGetAsString()
        {
            TraktSyncItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncItemType.Movie.AsString().Should().Be("movie");
            TraktSyncItemType.Show.AsString().Should().Be("show");
            TraktSyncItemType.Season.AsString().Should().Be("season");
            TraktSyncItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncItemTypeGetAsStringUriParameter()
        {
            TraktSyncItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Show);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Season);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncItemTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncItemType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncItemType.Unspecified);
        }
    }
}
