namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CertificationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().Be("Parental Guidance Suggested");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().Be("PG");
                traktCertification.Slug.Should().Be("pg");
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);

                traktCertification.Should().NotBeNull();
                traktCertification.Name.Should().BeNull();
                traktCertification.Slug.Should().BeNull();
                traktCertification.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            var traktCertification = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktCertification.Should().BeNull();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new CertificationObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCertification = await traktJsonReader.ReadObjectAsync(stream);
                traktCertification.Should().BeNull();
            }
        }
    }
}
