namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public class ITraktImageObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktImageObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktImageObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktImage>));
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(JSON_COMPLETE);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new ITraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(JSON_NOT_VALID);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(default(string));
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(string.Empty);
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = traktJsonReader.ReadObject(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = traktJsonReader.ReadObject(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktImageObjectJsonReader();

            var traktImage = jsonReader.ReadObject(default(JsonTextReader));
            traktImage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktImageObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

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
