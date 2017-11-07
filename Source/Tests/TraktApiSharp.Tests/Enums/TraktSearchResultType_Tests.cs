namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSearchResultType_Tests
    {
        private class TestObject
        {
            [JsonConverter(typeof(TraktEnumerationConverter<TraktSearchResultType>))]
            public TraktSearchResultType Value { get; set; }
        }

        [Fact]
        public void Test_TraktSearchResultType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchResultType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSearchResultType>() { TraktSearchResultType.Unspecified, TraktSearchResultType.Movie,
                                                                           TraktSearchResultType.Show, TraktSearchResultType.Episode,
                                                                           TraktSearchResultType.Person, TraktSearchResultType.List });
        }

        [Fact]
        public void Test_TraktSearchResultType_OrOperator()
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

            result = TraktSearchResultType.Movie;

            result.Value.Should().Be(1);
            result.ObjectName.Should().Be("movie");
            result.UriName.Should().Be("movie");
            result.DisplayName.Should().Be("Movie");

            var oldResult = result;
            result = TraktSearchResultType.Movie | TraktSearchResultType.Show;

            oldResult = result;
            result.Value.Should().Be(oldResult.Value | TraktSearchResultType.Show.Value);
            result.ObjectName.Should().Be("movie,show");
            result.UriName.Should().Be("movie,show");
            result.DisplayName.Should().Be("Movie, Show");

            oldResult = result;
            result |= TraktSearchResultType.Episode;

            result.Value.Should().Be(oldResult.Value | TraktSearchResultType.Episode.Value);
            result.ObjectName.Should().Be("movie,show,episode");
            result.UriName.Should().Be("movie,show,episode");
            result.DisplayName.Should().Be("Movie, Show, Episode");

            oldResult = result;
            result |= TraktSearchResultType.Person;

            result.Value.Should().Be(oldResult.Value | TraktSearchResultType.Person.Value);
            result.ObjectName.Should().Be("movie,show,episode,person");
            result.UriName.Should().Be("movie,show,episode,person");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person");

            oldResult = result;
            result |= TraktSearchResultType.List;

            result.Value.Should().Be(oldResult.Value | TraktSearchResultType.List.Value);
            result.ObjectName.Should().Be("movie,show,episode,person,list");
            result.UriName.Should().Be("movie,show,episode,person,list");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person, List");
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_Movie()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Movie };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Movie);
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_Show()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Show };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Show);
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_Episode()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Episode };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Episode);
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_Person()
        {
            var obj = new TestObject { Value = TraktSearchResultType.Person };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.Person);
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_List()
        {
            var obj = new TestObject { Value = TraktSearchResultType.List };

            var objWritten = JsonConvert.SerializeObject(obj);
            objWritten.Should().NotBeNullOrEmpty();

            var objRead = JsonConvert.DeserializeObject<TestObject>(objWritten);
            objRead.Should().NotBeNull();
            objRead.Value.Should().Be(TraktSearchResultType.List);
        }

        [Fact]
        public void Test_TraktSearchResultType_WriteAndReadJson_Unspecified()
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
