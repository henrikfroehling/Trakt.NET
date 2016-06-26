namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktListItemTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktListItemTypeConverter))]
            public TraktListItemType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktListItemTypeHasMembers()
        {
            typeof(TraktListItemType).GetEnumNames().Should().HaveCount(6)
                                                    .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode", "Person");
        }

        [TestMethod]
        public void TestTraktListItemTypeGetAsString()
        {
            TraktListItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktListItemType.Movie.AsString().Should().Be("movie");
            TraktListItemType.Show.AsString().Should().Be("show");
            TraktListItemType.Season.AsString().Should().Be("season");
            TraktListItemType.Episode.AsString().Should().Be("episode");
            TraktListItemType.Person.AsString().Should().Be("person");
        }

        [TestMethod]
        public void TestTraktListItemTypeGetAsStringUriParameter()
        {
            TraktListItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktListItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktListItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktListItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktListItemType.Episode.AsStringUriParameter().Should().Be("episodes");
            TraktListItemType.Person.AsStringUriParameter().Should().Be("people");
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktListItemType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Movie);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktListItemType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Show);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Season()
        {
            var obj = new TestObject { Value = TraktListItemType.Season };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Season);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktListItemType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Episode);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Person()
        {
            var obj = new TestObject { Value = TraktListItemType.Person };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktListItemType.Person);
        }

        [TestMethod]
        public void TestTraktListItemTypeWriteAndReadJson_Unspecified()
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
