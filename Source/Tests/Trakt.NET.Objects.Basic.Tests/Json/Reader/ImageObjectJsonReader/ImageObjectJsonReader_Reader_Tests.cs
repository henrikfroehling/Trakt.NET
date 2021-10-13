namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ImageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ImageObjectJsonReader();
            Func<Task<ITraktImage>> traktImage = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktImage.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktImage.Should().BeNull();
            }
        }
    }
}
