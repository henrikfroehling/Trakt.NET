namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCertifications.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().BeNull();
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().BeNull();
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().BeNull();

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().BeNull();
            items[1].Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().BeNull();
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().BeNull();
            items[1].Slug.Should().BeNull();
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().BeNull();
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().BeNull();
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().Be("pg");
            items[0].Description.Should().BeNull();

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);

            traktCertifications.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktCertifications.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("PG");
            items[0].Slug.Should().BeNull();
            items[0].Description.Should().Be("Parental Guidance Suggested");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("PG-13");
            items[1].Slug.Should().Be("pg-13");
            items[1].Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(default(string));
            traktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await jsonReader.ReadArrayAsync(string.Empty);
            traktCertifications.Should().BeNull();
        }
    }
}
