namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ErrorArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktErrors.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().Be("trakt error");
                errors[0].Description.Should().Be("trakt error description");

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().Be("trakt error");
                errors[1].Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().Be("trakt error");
                errors[0].Description.Should().Be("trakt error description");

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().Be("trakt error");
                errors[1].Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().Be("trakt error");
                errors[0].Description.Should().BeNull();

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().Be("trakt error");
                errors[1].Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().BeNull();
                errors[0].Description.Should().Be("trakt error description");

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().Be("trakt error");
                errors[1].Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().Be("trakt error");
                errors[0].Description.Should().Be("trakt error description");

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().BeNull();
                errors[1].Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktErrors.Should().NotBeNull();
                ITraktError[] errors = traktErrors.ToArray();

                errors[0].Should().NotBeNull();
                errors[0].Error.Should().BeNull();
                errors[0].Description.Should().Be("trakt error description");

                errors[1].Should().NotBeNull();
                errors[1].Error.Should().BeNull();
                errors[1].Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();
            Func<Task<IEnumerable<ITraktError>>> traktErrors = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktErrors.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktError>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktError> traktErrors = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktErrors.Should().BeNull();
            }
        }
    }
}
