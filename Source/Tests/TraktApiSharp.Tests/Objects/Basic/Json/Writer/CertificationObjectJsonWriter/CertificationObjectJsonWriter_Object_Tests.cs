namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CertificationObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CertificationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CertificationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktCertification));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCertification traktCertification = new TraktCertification();

            var traktJsonWriter = new CertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertification);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_Object_Only_Name_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Name = "certification name"
            };

            var traktJsonWriter = new CertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertification);
            json.Should().Be(@"{""name"":""certification name""}");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_Object_Only_Slug_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Slug = "certification slug"
            };

            var traktJsonWriter = new CertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertification);
            json.Should().Be(@"{""slug"":""certification slug""}");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_Object_Only_Description_Property()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Description = "certification description"
            };

            var traktJsonWriter = new CertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertification);
            json.Should().Be(@"{""description"":""certification description""}");
        }

        [Fact]
        public async Task Test_CertificationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCertification traktCertification = new TraktCertification
            {
                Name = "certification name",
                Slug = "certification slug",
                Description = "certification description"
            };

            var traktJsonWriter = new CertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertification);
            json.Should().Be(@"{""name"":""certification name"",""slug"":""certification slug"",""description"":""certification description""}");
        }
    }
}
