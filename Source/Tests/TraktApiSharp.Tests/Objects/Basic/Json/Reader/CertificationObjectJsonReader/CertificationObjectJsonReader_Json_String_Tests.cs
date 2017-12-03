namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().Be("Parental Guidance Suggested");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().Be("PG");
            traktCertification.Slug.Should().Be("pg");
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktCertification.Should().NotBeNull();
            traktCertification.Name.Should().BeNull();
            traktCertification.Slug.Should().BeNull();
            traktCertification.Description.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(default(string));
            traktCertification.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CertificationObjectJsonReader();

            var traktCertification = await jsonReader.ReadObjectAsync(string.Empty);
            traktCertification.Should().BeNull();
        }
    }
}
