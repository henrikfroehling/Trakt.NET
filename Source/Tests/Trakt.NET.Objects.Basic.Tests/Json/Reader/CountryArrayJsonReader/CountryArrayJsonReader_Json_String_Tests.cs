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

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CountryArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCountries.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().Be("Australia");
            countries[0].Code.Should().Be("au");

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().Be("Australia");
            countries[1].Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().Be("Australia");
            countries[0].Code.Should().Be("au");

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().BeNull();
            countries[1].Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().BeNull();
            countries[0].Code.Should().Be("au");

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().Be("Australia");
            countries[1].Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().Be("Australia");
            countries[0].Code.Should().Be("au");

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().BeNull();
            countries[1].Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().Be("Australia");
            countries[0].Code.Should().BeNull();

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().Be("Australia");
            countries[1].Code.Should().Be("au");
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktCountries.Should().NotBeNull();
            ITraktCountry[] countries = traktCountries.ToArray();

            countries[0].Should().NotBeNull();
            countries[0].Name.Should().BeNull();
            countries[0].Code.Should().Be("au");

            countries[1].Should().NotBeNull();
            countries[1].Name.Should().Be("Australia");
            countries[1].Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            Func<Task<IList<ITraktCountry>>> traktCountries = () => jsonReader.ReadArrayAsync(default(string));
            await traktCountries.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCountry>();
            IList<ITraktCountry> traktCountries = await jsonReader.ReadArrayAsync(string.Empty);
            traktCountries.Should().BeNull();
        }
    }
}
