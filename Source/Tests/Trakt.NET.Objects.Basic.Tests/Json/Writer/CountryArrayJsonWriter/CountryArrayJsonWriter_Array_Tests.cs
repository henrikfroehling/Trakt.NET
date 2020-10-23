namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CountryArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CountryArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<TraktCountry>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCountries);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<ITraktCountry>
            {
                new TraktCountry
                {
                    Name = "Australia",
                    Code = "au"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCountries);
            json.Should().Be(@"[{""name"":""Australia"",""code"":""au""}]");
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<ITraktCountry>
            {
                new TraktCountry
                {
                    Name = "Australia",
                    Code = "au"
                },
                new TraktCountry
                {
                    Name = "Japan",
                    Code = "ja"
                },
                new TraktCountry
                {
                    Name = "United States",
                    Code = "us"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCountries);
            json.Should().Be(@"[{""name"":""Australia"",""code"":""au""}," +
                             @"{""name"":""Japan"",""code"":""ja""}," +
                             @"{""name"":""United States"",""code"":""us""}]");
        }
    }
}
