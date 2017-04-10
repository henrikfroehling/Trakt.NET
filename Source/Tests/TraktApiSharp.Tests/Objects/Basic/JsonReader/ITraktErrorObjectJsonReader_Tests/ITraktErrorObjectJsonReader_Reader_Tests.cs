namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktErrorObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            var traktError = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktError.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktError.Should().BeNull();
            }
        }
    }
}
