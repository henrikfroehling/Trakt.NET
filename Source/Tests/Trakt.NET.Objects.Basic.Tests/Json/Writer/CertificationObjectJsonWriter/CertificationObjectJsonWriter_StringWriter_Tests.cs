namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CertificationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CertificationObjectJsonWriter();
            ITraktCertification traktCertification = new TraktCertification();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCertification);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktCertification traktCertification = new TraktCertification();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CertificationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCertification);
                json.Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Only_Name_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Name = "certification name"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CertificationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCertification);
                json.Should().Be(@"{""name"":""certification name""}");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Only_Slug_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Slug = "certification slug"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CertificationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCertification);
                json.Should().Be(@"{""slug"":""certification slug""}");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Only_Description_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Description = "certification description"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CertificationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCertification);
                json.Should().Be(@"{""description"":""certification description""}");
            }
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Name = "certification name",
                Slug = "certification slug",
                Description = "certification description"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CertificationObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCertification);
                json.Should().Be(@"{""name"":""certification name"",""slug"":""certification slug"",""description"":""certification description""}");
            }
        }
    }
}
