namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertifications.Should().NotBeNull();
                traktCertifications.US.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCertifications.Should().BeNull();
            }
        }
    }
}
