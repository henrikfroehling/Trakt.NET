namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Stream")]
    public partial class CertificationsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationsObjectStream_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CertificationsObjectStream_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(stream);

                traktCertifications.Should().NotBeNull();
                traktCertifications.US.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationsObjectStream_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            var traktCertifications = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationsObjectStream_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new CertificationsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCertifications = await traktJsonReader.ReadObjectAsync(stream);
                traktCertifications.Should().BeNull();
            }
        }
    }
}
