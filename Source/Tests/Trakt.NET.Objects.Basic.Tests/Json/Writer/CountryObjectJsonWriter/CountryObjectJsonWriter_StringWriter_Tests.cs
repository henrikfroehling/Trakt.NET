namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
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
        public async Task Test_CountryObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CountryObjectJsonWriter();
            ITraktCountry traktCountry = new TraktCountry();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCountry);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_StringWriter_Only_Name_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCountry);
                json.Should().Be(@"{""name"":""Australia""}");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_StringWriter_Only_Code_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Code = "au"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCountry);
                json.Should().Be(@"{""code"":""au""}");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia",
                Code = "au"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CountryObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCountry);
                json.Should().Be(@"{""name"":""Australia"",""code"":""au""}");
            }
        }
    }
}
