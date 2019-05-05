namespace TraktNet.Objects.Tests.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCountry_Tests
    {
        [Fact]
        public void Test_TraktCountry_Default_Constructor()
        {
            var traktCountry = new TraktCountry();

            traktCountry.Name.Should().BeNull();
            traktCountry.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCountry_From_Json()
        {
            var jsonReader = new CountryObjectJsonReader();
            var traktCountry = await jsonReader.ReadObjectAsync(JSON) as TraktCountry;

            traktCountry.Should().NotBeNull();
            traktCountry.Name.Should().Be("Australia");
            traktCountry.Code.Should().Be("au");
        }

        private const string JSON =
            @"{
                ""name"": ""Australia"",
                ""code"": ""au""
              }";
    }
}
