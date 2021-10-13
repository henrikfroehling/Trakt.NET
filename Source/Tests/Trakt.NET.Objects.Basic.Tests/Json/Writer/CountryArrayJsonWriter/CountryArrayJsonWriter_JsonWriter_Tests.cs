namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public async Task Test_CountryArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
            IEnumerable<ITraktCountry> traktCountries = new List<TraktCountry>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCountries);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCountry> traktCountries = new List<TraktCountry>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCountries);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCountries);
                stringWriter.ToString().Should().Be(@"[{""name"":""Australia"",""code"":""au""}]");
            }
        }

        [Fact]
        public async Task Test_CountryArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCountry>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCountries);
                stringWriter.ToString().Should().Be(@"[{""name"":""Australia"",""code"":""au""}," +
                                                    @"{""name"":""Japan"",""code"":""ja""}," +
                                                    @"{""name"":""United States"",""code"":""us""}]");
            }
        }
    }
}
