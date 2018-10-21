namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ErrorArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);
                traktErrors.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ErrorArrayJsonReader();
            IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(default(Stream));
            traktErrors.Should().BeNull();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ErrorArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktError> traktErrors = await jsonReader.ReadArrayAsync(stream);
                traktErrors.Should().BeNull();
            }
        }
    }
}
