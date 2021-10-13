namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CertificationObjectJsonReader();
            Func<Task<ITraktCertification>> traktCertification = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktCertification.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCertification.Should().BeNull();
            }
        }
    }
}
