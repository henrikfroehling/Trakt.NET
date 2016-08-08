namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
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
        public void TestTraktSearchResultTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSearchResultType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSearchResultTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchResultType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSearchResultType>() { TraktSearchResultType.Unspecified, TraktSearchResultType.Movie,
                                                                           TraktSearchResultType.Show, TraktSearchResultType.Episode,
                                                                           TraktSearchResultType.Person, TraktSearchResultType.List });
        }

        [TestMethod]
        public void TestTraktSearchResultTypeOrOperator()
        {
            var nullResult = default(TraktSearchResultType);

            var result = nullResult | TraktSearchResultType.Movie;
            result.Should().BeNull();

            result = TraktSearchResultType.Movie | nullResult;
            result.Should().BeNull();

            result = nullResult | nullResult;
            result.Should().BeNull();

            // -----------------------------------------------------

            result = TraktSearchResultType.Movie | TraktSearchResultType.Unspecified;
            result.Should().Be(TraktSearchResultType.Unspecified);

            result = TraktSearchResultType.Unspecified | TraktSearchResultType.Movie;
            result.Should().Be(TraktSearchResultType.Unspecified);

            result = TraktSearchResultType.Unspecified | TraktSearchResultType.Unspecified;
            result.Should().Be(TraktSearchResultType.Unspecified);

            // -----------------------------------------------------

            var movieResult = TraktSearchResultType.Movie;

            movieResult.Value.Should().Be(1);
            movieResult.ObjectName.Should().Be("movie");
            movieResult.UriName.Should().Be("movie");
            movieResult.DisplayName.Should().Be("Movie");

            var movieAndShowResult = TraktSearchResultType.Movie | TraktSearchResultType.Show;

            movieAndShowResult.Value.Should().Be(movieResult.Value | TraktSearchResultType.Show.Value);
            movieAndShowResult.ObjectName.Should().Be("movie,show");
            movieAndShowResult.UriName.Should().Be("movie,show");
            movieAndShowResult.DisplayName.Should().Be("Movie, Show");

            var movieAndShowAndEpisodeResult = movieAndShowResult | TraktSearchResultType.Episode;

            movieAndShowAndEpisodeResult.Value.Should().Be(movieAndShowResult.Value | TraktSearchResultType.Episode.Value);
            movieAndShowAndEpisodeResult.ObjectName.Should().Be("movie,show,episode");
            movieAndShowAndEpisodeResult.UriName.Should().Be("movie,show,episode");
            movieAndShowAndEpisodeResult.DisplayName.Should().Be("Movie, Show, Episode");

            var movieAndShowAndEpisodeAndPersonResult = movieAndShowAndEpisodeResult | TraktSearchResultType.Person;

            movieAndShowAndEpisodeAndPersonResult.Value.Should().Be(movieAndShowAndEpisodeResult.Value | TraktSearchResultType.Person.Value);
            movieAndShowAndEpisodeAndPersonResult.ObjectName.Should().Be("movie,show,episode,person");
            movieAndShowAndEpisodeAndPersonResult.UriName.Should().Be("movie,show,episode,person");
            movieAndShowAndEpisodeAndPersonResult.DisplayName.Should().Be("Movie, Show, Episode, Person");

            var movieAndShowAndEpisodeAndPersonAndListResult = movieAndShowAndEpisodeAndPersonResult | TraktSearchResultType.List;

            movieAndShowAndEpisodeAndPersonAndListResult.Value.Should().Be(movieAndShowAndEpisodeAndPersonResult.Value | TraktSearchResultType.List.Value);
            movieAndShowAndEpisodeAndPersonAndListResult.ObjectName.Should().Be("movie,show,episode,person,list");
            movieAndShowAndEpisodeAndPersonAndListResult.UriName.Should().Be("movie,show,episode,person,list");
            movieAndShowAndEpisodeAndPersonAndListResult.DisplayName.Should().Be("Movie, Show, Episode, Person, List");
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
