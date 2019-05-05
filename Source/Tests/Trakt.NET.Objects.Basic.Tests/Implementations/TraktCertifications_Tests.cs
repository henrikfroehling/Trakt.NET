namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCertifications_Tests
    {
        [Fact]
        public void Test_TraktCertifications_Default_Constructor()
        {
            var traktCertifications = new TraktCertifications();

            traktCertifications.US.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCertifications_From_Json()
        {
            var jsonReader = new CertificationsObjectJsonReader();
            var traktCertifications = await jsonReader.ReadObjectAsync(JSON) as TraktCertifications;

            traktCertifications.Should().NotBeNull();
            traktCertifications.US.Should().NotBeNull();
            traktCertifications.US.Should().NotBeEmpty().And.HaveCount(2);

            var certifications = traktCertifications.US.ToArray();

            certifications[0].Should().NotBeNull();
            certifications[0].Name.Should().Be("PG");
            certifications[0].Slug.Should().Be("pg");
            certifications[0].Description.Should().Be("Parental Guidance Suggested");

            certifications[1].Should().NotBeNull();
            certifications[1].Name.Should().Be("PG-13");
            certifications[1].Slug.Should().Be("pg-13");
            certifications[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        private const string JSON =
            @"{
                ""us"": [
                  {
                    ""name"": ""PG"",
                    ""slug"": ""pg"",
                    ""description"": ""Parental Guidance Suggested""
                  },
                  {
                    ""name"": ""PG-13"",
                    ""slug"": ""pg-13"",
                    ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                  }
                ]
              }";
    }
}
