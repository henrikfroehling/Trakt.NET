namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);
                multipleTraktCertifications.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeEmpty().And.HaveCount(2);

                ITraktCertification[] certifications = traktCertifications[0].US.ToArray();

                certifications[0].Should().NotBeNull();
                certifications[0].Name.Should().Be("PG");
                certifications[0].Slug.Should().Be("pg");
                certifications[0].Description.Should().Be("Parental Guidance Suggested");

                certifications[1].Should().NotBeNull();
                certifications[1].Name.Should().Be("PG-13");
                certifications[1].Slug.Should().Be("pg-13");
                certifications[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeEmpty().And.HaveCount(2);

                certifications = traktCertifications[1].US.ToArray();

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeEmpty().And.HaveCount(2);

                ITraktCertification[] certifications = traktCertifications[0].US.ToArray();

                certifications[0].Should().NotBeNull();
                certifications[0].Name.Should().Be("PG");
                certifications[0].Slug.Should().Be("pg");
                certifications[0].Description.Should().Be("Parental Guidance Suggested");

                certifications[1].Should().NotBeNull();
                certifications[1].Name.Should().Be("PG-13");
                certifications[1].Slug.Should().Be("pg-13");
                certifications[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeEmpty().And.HaveCount(2);

                certifications = traktCertifications[1].US.ToArray();

                certifications[0].Should().NotBeNull();
                certifications[0].Name.Should().Be("PG");
                certifications[0].Slug.Should().Be("pg");
                certifications[0].Description.Should().BeNull();

                certifications[1].Should().NotBeNull();
                certifications[1].Name.Should().Be("PG-13");
                certifications[1].Slug.Should().Be("pg-13");
                certifications[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeEmpty().And.HaveCount(2);

                ITraktCertification[] certifications = traktCertifications[0].US.ToArray();

                certifications[0].Should().NotBeNull();
                certifications[0].Name.Should().Be("PG");
                certifications[0].Slug.Should().Be("pg");
                certifications[0].Description.Should().Be("Parental Guidance Suggested");

                certifications[1].Should().NotBeNull();
                certifications[1].Name.Should().Be("PG-13");
                certifications[1].Slug.Should().Be("pg-13");
                certifications[1].Description.Should().BeNull();

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeEmpty().And.HaveCount(2);

                certifications = traktCertifications[1].US.ToArray();

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().BeNull();

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeNull();
                traktCertifications[1].US.Should().NotBeEmpty().And.HaveCount(2);

                ITraktCertification[] certifications = traktCertifications[1].US.ToArray();

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeNull();
                traktCertifications[0].US.Should().NotBeEmpty().And.HaveCount(2);

                ITraktCertification[] certifications = traktCertifications[0].US.ToArray();

                certifications[0].Should().NotBeNull();
                certifications[0].Name.Should().Be("PG");
                certifications[0].Slug.Should().Be("pg");
                certifications[0].Description.Should().Be("Parental Guidance Suggested");

                certifications[1].Should().NotBeNull();
                certifications[1].Name.Should().Be("PG-13");
                certifications[1].Slug.Should().Be("pg-13");
                certifications[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().BeNull();

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new CertificationsArrayJsonReader();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(default(Stream));
            multipleTraktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new CertificationsArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(stream);
                multipleTraktCertifications.Should().BeNull();
            }
        }
    }
}
