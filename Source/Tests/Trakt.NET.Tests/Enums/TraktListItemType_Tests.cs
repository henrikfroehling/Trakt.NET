namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
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
        public void Test_TraktListItemType_OrOperator()
        {
            var nullResult = default(TraktListItemType);

            var result = nullResult | TraktListItemType.Movie;
            result.Should().BeNull();

            result = TraktListItemType.Movie | nullResult;
            result.Should().BeNull();

            result = nullResult | nullResult;
            result.Should().BeNull();

            // -----------------------------------------------------

            result = TraktListItemType.Movie | TraktListItemType.Unspecified;
            result.Should().Be(TraktListItemType.Unspecified);

            result = TraktListItemType.Unspecified | TraktListItemType.Movie;
            result.Should().Be(TraktListItemType.Unspecified);

            result = TraktListItemType.Unspecified | TraktListItemType.Unspecified;
            result.Should().Be(TraktListItemType.Unspecified);

            // -----------------------------------------------------

            result = TraktListItemType.Movie;

            result.Value.Should().Be(1);
            result.ObjectName.Should().Be("movie");
            result.UriName.Should().Be("movies");
            result.DisplayName.Should().Be("Movie");

            var oldResult = result;
            result = TraktListItemType.Movie | TraktListItemType.Show;

            oldResult = result;
            result.Value.Should().Be(oldResult.Value | TraktListItemType.Show.Value);
            result.ObjectName.Should().Be("movie,show");
            result.UriName.Should().Be("movies,shows");
            result.DisplayName.Should().Be("Movie, Show");

            oldResult = result;
            result |= TraktListItemType.Episode;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Episode.Value);
            result.ObjectName.Should().Be("movie,show,episode");
            result.UriName.Should().Be("movies,shows,episodes");
            result.DisplayName.Should().Be("Movie, Show, Episode");

            oldResult = result;
            result |= TraktListItemType.Person;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Person.Value);
            result.ObjectName.Should().Be("movie,show,episode,person");
            result.UriName.Should().Be("movies,shows,episodes,people");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person");

            oldResult = result;
            result |= TraktListItemType.Season;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Season.Value);
            result.ObjectName.Should().Be("movie,show,episode,person,season");
            result.UriName.Should().Be("movies,shows,episodes,people,seasons");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person, Season");
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
