namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktCertification_Tests
    {
        [Fact]
        public void Test_TraktCertification_Default_Constructor()
        {
            var traktCertification = new TraktCertification();

            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCertification_From_Json()
        {
            var jsonReader = new CertificationObjectJsonReader();
            var traktCertification = await jsonReader.ReadObjectAsync(JSON) as TraktCertification;

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        private const string JSON =
            @"{
                ""name"": ""PG"",
                ""slug"": ""pg"",
                ""description"": ""Parental Guidance Suggested""
              }";
    }
}
