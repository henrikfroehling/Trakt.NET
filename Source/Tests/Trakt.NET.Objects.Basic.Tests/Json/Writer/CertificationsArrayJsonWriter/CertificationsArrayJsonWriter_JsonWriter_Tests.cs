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
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CertificationsArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
            IEnumerable<ITraktCertifications> traktCertifications = new List<TraktCertifications>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCertifications);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCertifications> traktCertifications = new List<TraktCertifications>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCertifications> traktCertifications = new List<ITraktCertifications>
            {
                new TraktCertifications
                {
                    US = new List<ITraktCertification>
                    {
                        new TraktCertification
                        {
                            Name = "certification name 1.1",
                            Slug = "certification slug 1.1",
                            Description = "certification description 1.1"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 1.2",
                            Slug = "certification slug 1.2",
                            Description = "certification description 1.2"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 1.3",
                            Slug = "certification slug 1.3",
                            Description = "certification description 1.3"
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be(@"[{""us"":[{""name"":""certification name 1.1"",""slug"":""certification slug 1.1"",""description"":""certification description 1.1""}," +
                                                    @"{""name"":""certification name 1.2"",""slug"":""certification slug 1.2"",""description"":""certification description 1.2""}," +
                                                    @"{""name"":""certification name 1.3"",""slug"":""certification slug 1.3"",""description"":""certification description 1.3""}]}]");
            }
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCertifications> traktCertifications = new List<ITraktCertifications>
            {
                new TraktCertifications
                {
                    US = new List<ITraktCertification>
                    {
                        new TraktCertification
                        {
                            Name = "certification name 1.1",
                            Slug = "certification slug 1.1",
                            Description = "certification description 1.1"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 1.2",
                            Slug = "certification slug 1.2",
                            Description = "certification description 1.2"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 1.3",
                            Slug = "certification slug 1.3",
                            Description = "certification description 1.3"
                        }
                    }
                },
                new TraktCertifications
                {
                    US = new List<ITraktCertification>
                    {
                        new TraktCertification
                        {
                            Name = "certification name 2.1",
                            Slug = "certification slug 2.1",
                            Description = "certification description 2.1"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 2.2",
                            Slug = "certification slug 2.2",
                            Description = "certification description 2.2"
                        },
                        new TraktCertification
                        {
                            Name = "certification name 2.3",
                            Slug = "certification slug 2.3",
                            Description = "certification description 2.3"
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCertifications);
                stringWriter.ToString().Should().Be(@"[{""us"":[{""name"":""certification name 1.1"",""slug"":""certification slug 1.1"",""description"":""certification description 1.1""}," +
                                                    @"{""name"":""certification name 1.2"",""slug"":""certification slug 1.2"",""description"":""certification description 1.2""}," +
                                                    @"{""name"":""certification name 1.3"",""slug"":""certification slug 1.3"",""description"":""certification description 1.3""}]}," +
                                                    @"{""us"":[{""name"":""certification name 2.1"",""slug"":""certification slug 2.1"",""description"":""certification description 2.1""}," +
                                                    @"{""name"":""certification name 2.2"",""slug"":""certification slug 2.2"",""description"":""certification description 2.2""}," +
                                                    @"{""name"":""certification name 2.3"",""slug"":""certification slug 2.3"",""description"":""certification description 2.3""}]}]");
            }
        }
    }
}
