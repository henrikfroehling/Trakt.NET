namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CountryArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCountries.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().Be("Australia");
                countries[0].Code.Should().Be("au");

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().Be("Australia");
                countries[1].Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().Be("Australia");
                countries[0].Code.Should().Be("au");

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().BeNull();
                countries[1].Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().BeNull();
                countries[0].Code.Should().Be("au");

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().Be("Australia");
                countries[1].Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().Be("Australia");
                countries[0].Code.Should().Be("au");

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().BeNull();
                countries[1].Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().Be("Australia");
                countries[0].Code.Should().BeNull();

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().Be("Australia");
                countries[1].Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCountries.Should().NotBeNull();
                ITraktCountry[] countries = traktCountries.ToArray();

                countries[0].Should().NotBeNull();
                countries[0].Name.Should().BeNull();
                countries[0].Code.Should().Be("au");

                countries[1].Should().NotBeNull();
                countries[1].Name.Should().Be("Australia");
                countries[1].Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new CountryArrayJsonReader();
            IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCountries.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new CountryArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCountry> traktCountries = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCountries.Should().BeNull();
            }
        }
    }
}
