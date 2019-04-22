namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class ErrorArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_ErrorArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktError> traktError = new List<TraktError>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            string json = await traktJsonWriter.WriteArrayAsync(traktError);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktError> traktError = new List<ITraktError>
            {
                new TraktError
                {
                    Error = "error 1",
                    Description = "error description 1"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            string json = await traktJsonWriter.WriteArrayAsync(traktError);
            json.Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}]");
        }

        [Fact]
        public async Task Test_ErrorArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktError>();
            string json = await traktJsonWriter.WriteArrayAsync(traktError);
            json.Should().Be(@"[{""error"":""error 1"",""error_description"":""error description 1""}," +
                                @"{""error"":""error 2"",""error_description"":""error description 2""}]");
        }
    }
}
