namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CertificationsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CertificationsObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CertificationsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCertifications traktCertifications = new TraktCertifications();
            var traktJsonWriter = new CertificationsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertifications);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCertifications traktCertifications = new TraktCertifications
            {
                US = new List<ITraktCertification>
                     {
                          new TraktCertification
                         {
                             Name = "certification name 1",
                             Slug = "certification slug 1",
                             Description = "certification description 1"
                         },
                         new TraktCertification
                         {
                             Name = "certification name 2",
                             Slug = "certification slug 2",
                             Description = "certification description 2"
                         },
                         new TraktCertification
                         {
                             Name = "certification name 3",
                             Slug = "certification slug 3",
                             Description = "certification description 3"
                         }
                    }
            };

            var traktJsonWriter = new CertificationsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCertifications);
            json.Should().Be(@"{""us"":[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}," +
                             @"{""name"":""certification name 2"",""slug"":""certification slug 2"",""description"":""certification description 2""}," +
                             @"{""name"":""certification name 3"",""slug"":""certification slug 3"",""description"":""certification description 3""}]}");
        }
    }
}
