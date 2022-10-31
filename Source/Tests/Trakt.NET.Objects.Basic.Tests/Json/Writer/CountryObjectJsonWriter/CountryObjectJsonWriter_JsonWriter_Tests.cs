namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CountryObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CountryObjectJsonWriter();
            ITraktCountry traktCountry = new TraktCountry();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCountry);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_JsonWriter_Only_Name_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCountry);
                stringWriter.ToString().Should().Be(@"{""name"":""Australia""}");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_JsonWriter_Only_Code_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Code = "au"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCountry);
                stringWriter.ToString().Should().Be(@"{""code"":""au""}");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia",
                Code = "au"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCountry);
                stringWriter.ToString().Should().Be(@"{""name"":""Australia"",""code"":""au""}");
            }
        }
    }
}
