namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktErrorObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(default(string));
            traktError.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktErrorObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktErrorObjectJsonReader();

            var traktError = await jsonReader.ReadObjectAsync(string.Empty);
            traktError.Should().BeNull();
        }
    }
}
