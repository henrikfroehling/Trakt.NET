namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCertifications.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            var traktCertifications = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCertifications.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new CertificationArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertifications = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCertifications.Should().BeNull();
            }
        }
    }
}
