namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CountryObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CountryObjectJsonReader();
            Func<Task<ITraktCountry>> traktCountry = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktCountry.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCountry.Should().BeNull();
            }
        }
    }
}
