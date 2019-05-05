namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CountryObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().Be("Australia");
            traktCountry.Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().BeNull();
            traktCountry.Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().Be("Australia");
            traktCountry.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().BeNull();
            traktCountry.Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().Be("Australia");
            traktCountry.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().BeNull();
            traktCountry.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(default(string));
            traktCountry.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CountryObjectJsonReader();
            ITraktCountry traktCountry = await jsonReader.ReadObjectAsync(string.Empty);
            traktCountry.Should().BeNull();
        }
    }
}
