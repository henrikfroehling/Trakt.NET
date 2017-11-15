namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktCertifications.Should().NotBeNull();
            traktCertifications.US.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await jsonReader.ReadObjectAsync(default(string));
            traktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await jsonReader.ReadObjectAsync(string.Empty);
            traktCertifications.Should().BeNull();
        }
    }
}
