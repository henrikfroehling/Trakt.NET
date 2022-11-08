﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class ErrorObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ErrorObjectJsonWriter();
            ITraktError traktError = new TraktError();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktError);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktError traktError = new TraktError();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktError);
                json.Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_StringWriter_Only_Error_Property()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktError);
                json.Should().Be(@"{""error"":""error""}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_StringWriter_Only_Description_Property()
        {
            ITraktError traktError = new TraktError
            {
                Description = "error description"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktError);
                json.Should().Be(@"{""error_description"":""error description""}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error",
                Description = "error description"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktError);
                json.Should().Be(@"{""error"":""error"",""error_description"":""error description""}");
            }
        }
    }
}
