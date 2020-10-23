namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
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
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            multipleTraktCertifications.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            multipleTraktCertifications.Should().NotBeNull();
            ITraktCertifications[] traktCertifications = multipleTraktCertifications.ToArray();

            traktCertifications[0].Should().NotBeNull();
            traktCertifications[0].US.Should().BeNull();

            traktCertifications[1].Should().NotBeNull();
            traktCertifications[1].US.Should().BeNull();
        }

        [Fact]
        public void Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            Func<Task<IEnumerable<ITraktCertifications>>> multipleTraktCertifications = () => jsonReader.ReadArrayAsync(default(string));
            multipleTraktCertifications.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCertifications>();
            IEnumerable<ITraktCertifications> multipleTraktCertifications = await jsonReader.ReadArrayAsync(string.Empty);
            multipleTraktCertifications.Should().BeNull();
        }
    }
}
