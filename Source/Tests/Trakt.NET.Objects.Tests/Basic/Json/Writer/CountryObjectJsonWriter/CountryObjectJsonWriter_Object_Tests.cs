namespace Trakt.NET.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CountryObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CountryObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CountryObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_Object_Only_Name_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia"
            };

            var traktJsonWriter = new CountryObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCountry);
            json.Should().Be(@"{""name"":""Australia""}");
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_Object_Only_Code_Property()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Code = "au"
            };

            var traktJsonWriter = new CountryObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCountry);
            json.Should().Be(@"{""code"":""au""}");
        }

        [Fact]
        public async Task Test_CountryObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCountry traktCountry = new TraktCountry
            {
                Name = "Australia",
                Code = "au"
            };

            var traktJsonWriter = new CountryObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCountry);
            json.Should().Be(@"{""name"":""Australia"",""code"":""au""}");
        }
    }
}
