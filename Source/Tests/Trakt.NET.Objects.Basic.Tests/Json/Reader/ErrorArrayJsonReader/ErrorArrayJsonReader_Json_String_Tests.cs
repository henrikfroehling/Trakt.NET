namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktErrors.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().Be("trakt error");
            errors[0].Description.Should().Be("trakt error description");

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().Be("trakt error");
            errors[1].Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().Be("trakt error");
            errors[0].Description.Should().Be("trakt error description");

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().Be("trakt error");
            errors[1].Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().Be("trakt error");
            errors[0].Description.Should().BeNull();

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().Be("trakt error");
            errors[1].Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().BeNull();
            errors[0].Description.Should().Be("trakt error description");

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().Be("trakt error");
            errors[1].Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().Be("trakt error");
            errors[0].Description.Should().Be("trakt error description");

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().BeNull();
            errors[1].Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktErrors.Should().NotBeNull();
            ITraktError[] errors = traktErrors.ToArray();

            errors[0].Should().NotBeNull();
            errors[0].Error.Should().BeNull();
            errors[0].Description.Should().Be("trakt error description");

            errors[1].Should().NotBeNull();
            errors[1].Error.Should().BeNull();
            errors[1].Description.Should().Be("trakt error description");
        }

        [Fact]
        public void Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            Func<Task<IEnumerable<ITraktError>>> traktErrors = () => jsonReader.ReadArrayAsync(default(string));
            traktErrors.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktError>();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(string.Empty);
            traktErrors.Should().BeNull();
        }
    }
}
