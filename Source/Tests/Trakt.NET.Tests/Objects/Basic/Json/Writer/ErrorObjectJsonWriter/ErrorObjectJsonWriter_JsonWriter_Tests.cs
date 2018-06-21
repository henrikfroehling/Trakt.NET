namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class ErrorObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_ErrorObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ErrorObjectJsonWriter();
            ITraktError traktError = new TraktError();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktError);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktError traktError = new TraktError();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_JsonWriter_Only_Error_Property()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be(@"{""error"":""error""}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_JsonWriter_Only_Description_Property()
        {
            ITraktError traktError = new TraktError
            {
                Description = "error description"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be(@"{""error_description"":""error description""}");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error",
                Description = "error description"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ErrorObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktError);
                stringWriter.ToString().Should().Be(@"{""error"":""error"",""error_description"":""error description""}");
            }
        }
    }
}
