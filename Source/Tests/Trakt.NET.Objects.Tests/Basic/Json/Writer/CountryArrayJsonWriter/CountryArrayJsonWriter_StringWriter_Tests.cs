namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CountryArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CountryArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            IEnumerable<ITraktCountry> traktCountries = new List<TraktCountry>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktCountries);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<TraktCountry>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCountries);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<ITraktCountry>
            {
                new TraktCountry
                {
                    Name = "Australia",
                    Code = "au"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCountries);
                json.Should().Be(@"[{""name"":""Australia"",""code"":""au""}]");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_StringWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktCountries);
                json.Should().Be(@"[{""name"":""Australia"",""code"":""au""}," +
                                 @"{""name"":""Japan"",""code"":""ja""}," +
                                 @"{""name"":""United States"",""code"":""us""}]");
            }
        }
    }
}
