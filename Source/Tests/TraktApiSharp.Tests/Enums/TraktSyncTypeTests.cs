namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSyncTypeConverter))]
            public TraktSyncType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSyncTypeHasMembers()
        {
            typeof(TraktSyncType).GetEnumNames().Should().HaveCount(3)
                                                         .And.Contain("Unspecified", "Movie", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncTypeGetAsString()
        {
            TraktSyncType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncType.Movie.AsString().Should().Be("movie");
            TraktSyncType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncTypeGetAsStringUriParameter()
        {
            TraktSyncType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncType.Episode.AsStringUriParameter().Should().Be("episodes");
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSyncType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Movie);
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSyncType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Episode);
        }

        [TestMethod]
        public void TestTraktSyncTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSyncType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSyncType.Unspecified);
        }
    }
}
