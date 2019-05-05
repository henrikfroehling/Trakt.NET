namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CertificationsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CertificationsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CertificationsObjectJsonWriter();
            ITraktCertifications traktCertifications = new TraktCertifications();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCertifications);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktCertifications traktCertifications = new TraktCertifications();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CertificationsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_CertificationsObjectJsonWriter_WriteObject_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CertificationsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be(@"{""us"":[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}," +
                                                    @"{""name"":""certification name 2"",""slug"":""certification slug 2"",""description"":""certification description 2""}," +
                                                    @"{""name"":""certification name 3"",""slug"":""certification slug 3"",""description"":""certification description 3""}]}");
            }
        }
    }
}
