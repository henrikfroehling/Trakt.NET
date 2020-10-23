namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);
                multipleTraktCertifications.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

                multipleTraktCertifications.Should().NotBeNull();
                ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

                traktCertifications[0].Should().NotBeNull();
                traktCertifications[0].US.Should().BeNull();

                traktCertifications[1].Should().NotBeNull();
                traktCertifications[1].US.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();
            Func<Task<IEnumerable<ITraktCertifications>>> multipleTraktCertifications = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            multipleTraktCertifications.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktCertifications>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCertifications> multipleTraktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);
                multipleTraktCertifications.Should().BeNull();
            }
        }
    }
}
