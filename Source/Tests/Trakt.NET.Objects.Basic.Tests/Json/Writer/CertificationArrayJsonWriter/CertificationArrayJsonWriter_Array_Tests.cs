﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
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
    public partial class CertificationArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCertification> traktCertifications = new List<TraktCertification>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be(@"[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}]");
        }

        [Fact]
        public async Task Test_CertificationArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktCertification>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCertifications);
            json.Should().Be(@"[{""name"":""certification name 1"",""slug"":""certification slug 1"",""description"":""certification description 1""}," +
                             @"{""name"":""certification name 2"",""slug"":""certification slug 2"",""description"":""certification description 2""}," +
                             @"{""name"":""certification name 3"",""slug"":""certification slug 3"",""description"":""certification description 3""}]");
        }
    }
}
