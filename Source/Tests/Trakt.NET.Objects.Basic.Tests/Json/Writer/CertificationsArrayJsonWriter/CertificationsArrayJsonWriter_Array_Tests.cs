namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CertificationsArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCertifications> traktCertifications = new List<TraktCertifications>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be(@"[{""us"":[{""name"":""certification name 1.1"",""slug"":""certification slug 1.1"",""description"":""certification description 1.1""}," +
                             @"{""name"":""certification name 1.2"",""slug"":""certification slug 1.2"",""description"":""certification description 1.2""}," +
                             @"{""name"":""certification name 1.3"",""slug"":""certification slug 1.3"",""description"":""certification description 1.3""}]}]");
        }

        [Fact]
        public async Task Test_CertificationsArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCertifications>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be(@"[{""us"":[{""name"":""certification name 1.1"",""slug"":""certification slug 1.1"",""description"":""certification description 1.1""}," +
                                @"{""name"":""certification name 1.2"",""slug"":""certification slug 1.2"",""description"":""certification description 1.2""}," +
                                @"{""name"":""certification name 1.3"",""slug"":""certification slug 1.3"",""description"":""certification description 1.3""}]}," +
                                @"{""us"":[{""name"":""certification name 2.1"",""slug"":""certification slug 2.1"",""description"":""certification description 2.1""}," +
                                @"{""name"":""certification name 2.2"",""slug"":""certification slug 2.2"",""description"":""certification description 2.2""}," +
                                @"{""name"":""certification name 2.3"",""slug"":""certification slug 2.3"",""description"":""certification description 2.3""}]}]");
        }
    }
}
