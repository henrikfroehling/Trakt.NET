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
    public partial class ErrorArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            IEnumerable<ITraktError> traktError = new List<TraktError>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktError);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktError> traktError = new List<TraktError>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}]");
            }
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}," +
                                                    @"{""error"":""error 2"",""error_description"":""error description 2""}]");
            }
        }
    }
}
