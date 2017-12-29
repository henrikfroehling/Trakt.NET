namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class ErrorObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_ErrorObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ErrorObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktError));
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktError traktError = new TraktError();

            var traktJsonWriter = new ErrorObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktError);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_Object_Only_Error_Property()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error"
            };

            var traktJsonWriter = new ErrorObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktError);
            json.Should().Be(@"{""error"":""error""}");
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_Object_Only_Description_Property()
        {
            ITraktError traktError = new TraktError
            {
                Description = "error description"
            };

            var traktJsonWriter = new ErrorObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktError);
            json.Should().Be(@"{""error_description"":""error description""}");
        }

        [Fact]
        public async Task Test_ErrorObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktError traktError = new TraktError
            {
                Error = "error",
                Description = "error description"
            };

            var traktJsonWriter = new ErrorObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktError);
            json.Should().Be(@"{""error"":""error"",""error_description"":""error description""}");
        }
    }
}
