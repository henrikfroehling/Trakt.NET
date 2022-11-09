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

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class ErrorObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

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
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ErrorObjectJsonReader();
            Func<Task<ITraktError>> traktError = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktError.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktError.Should().BeNull();
            }
        }
    }
}
