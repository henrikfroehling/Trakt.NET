namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchIdLookupTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSearchIdLookupTypeConverter))]
            public TraktSearchIdLookupType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeHasMembers()
        {
            typeof(TraktSearchIdLookupType).GetEnumNames().Should().HaveCount(8)
                                                          .And.Contain("TraktMovie", "TraktShow", "TraktEpisode", "ImDB", "TmDB", "TvDB", "TVRage", "Unspecified");
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeGetAsString()
        {
            TraktSearchIdLookupType.TraktMovie.AsString().Should().Be("trakt-movie");
            TraktSearchIdLookupType.TraktShow.AsString().Should().Be("trakt-show");
            TraktSearchIdLookupType.TraktEpisode.AsString().Should().Be("trakt-episode");
            TraktSearchIdLookupType.ImDB.AsString().Should().Be("imdb");
            TraktSearchIdLookupType.TmDB.AsString().Should().Be("tmdb");
            TraktSearchIdLookupType.TvDB.AsString().Should().Be("tvdb");
            TraktSearchIdLookupType.TVRage.AsString().Should().Be("tvrage");
            TraktSearchIdLookupType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktMovie()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktMovie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktMovie);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktShow()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktShow };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktShow);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TraktEpisode()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TraktEpisode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TraktEpisode);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_ImDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.ImDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.ImDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TmDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TmDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TmDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TvDB()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TvDB };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TvDB);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_TVRage()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.TVRage };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.TVRage);
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSearchIdLookupType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchIdLookupType.Unspecified);
        }
    }
}
