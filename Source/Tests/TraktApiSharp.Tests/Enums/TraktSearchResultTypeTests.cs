namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchResultTypeTests
    {
        class TestObject
        {
            [JsonConverter(typeof(TraktSearchResultTypeConverter))]
            public TraktSearchResultType Value { get; set; }
        }

        [TestMethod]
        public void TestTraktSearchResultTypeHasMembers()
        {
            typeof(TraktSearchResultType).GetEnumNames().Should().HaveCount(6)
                                                        .And.Contain("Movie", "Show", "Episode", "Person", "List", "Unspecified");
        }

        [TestMethod]
        public void TestTraktSearchResultTypeGetAsString()
        {
            TraktSearchResultType.Movie.AsString().Should().Be("movie");
            TraktSearchResultType.Show.AsString().Should().Be("show");
            TraktSearchResultType.Episode.AsString().Should().Be("episode");
            TraktSearchResultType.Person.AsString().Should().Be("person");
            TraktSearchResultType.List.AsString().Should().Be("list");
            TraktSearchResultType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Movie);
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Show);
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Episode);
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_Person()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Person };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Person);
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktSearchResultType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.List);
        }

        [TestMethod]
        public void TestTraktSearchResultTypeWriteAndReadJson_Unspecified()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Unspecified };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Unspecified);
        }
    }
}
