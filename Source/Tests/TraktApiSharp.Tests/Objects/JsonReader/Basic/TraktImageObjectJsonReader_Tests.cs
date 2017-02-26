namespace TraktApiSharp.Tests.Objects.JsonReader.Basic
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Basic;
    using Xunit;

    [Category("Objects.JsonReader.Basic")]
    public class TraktImageObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktImageObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktImageObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktImage>));
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(JSON_COMPLETE);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new TraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(JSON_NOT_VALID);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().BeNull();
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(default(string));
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(string.Empty);
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktImageObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = traktJsonReader.ReadObject(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new TraktImageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = traktJsonReader.ReadObject(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(default(JsonTextReader));
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktImageObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktImageObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = traktJsonReader.ReadObject(jsonReader);
                traktImage.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""fu"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png""
              }";
    }
}
