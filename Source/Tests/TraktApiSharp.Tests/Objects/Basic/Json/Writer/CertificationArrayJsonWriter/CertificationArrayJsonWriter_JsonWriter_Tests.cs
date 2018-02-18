namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CertificationArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CertificationArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
            IEnumerable<ITraktCertification> traktCertifications = new List<TraktCertification>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCertifications);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCertification> traktCertifications = new List<TraktCertification>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCertification> traktCertifications = new List<ITraktCertification>
            {
                new TraktCertification
                {
                    Name = "certification name 1",
                    Slug = "certification slug 1",
                    Description = "certification description 1"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be(@"[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}]");
            }
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCertification> traktCertifications = new List<ITraktCertification>
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be(@"[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}," +
                                                    @"{""name"":""certification name 2"",""slug"":""certification slug 2"",""description"":""certification description 2""}," +
                                                    @"{""name"":""certification name 3"",""slug"":""certification slug 3"",""description"":""certification description 3""}]");
            }
        }
    }
}
