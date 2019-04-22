namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class ErrorArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_ErrorArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            IEnumerable<ITraktError> traktError = new List<TraktError>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktError);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktError> traktError = new List<TraktError>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktError);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktError> traktError = new List<ITraktError>
            {
                new TraktError
                {
                    Error = "error 1",
                    Description = "error description 1"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktError);
                json.Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}]");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktError> traktError = new List<ITraktError>
            {
                new TraktError
                {
                    Error = "error 1",
                    Description = "error description 1"
                },
                new TraktError
                {
                    Error = "error 2",
                    Description = "error description 2"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktError);
                json.Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}," +
                                                    @"{""error"":""error 2"",""error_description"":""error description 2""}]");
            }
        }
    }
}
