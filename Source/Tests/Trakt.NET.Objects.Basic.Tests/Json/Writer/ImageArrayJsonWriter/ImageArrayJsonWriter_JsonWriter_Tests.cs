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
    public partial class ImageArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            IEnumerable<ITraktImage> traktImage = new List<TraktImage>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktImage> traktImage = new List<TraktImage>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktImage> traktImage = new List<ITraktImage>
            {
                new TraktImage
                {
                    Full = "fullPath 1"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"[{""full"":""fullPath 1""}]");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktImage> traktImage = new List<ITraktImage>
            {
                new TraktImage
                {
                    Full = "fullPath 1"
                },
                new TraktImage
                {
                    Full = "fullPath 2"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"[{""full"":""fullPath 1""},{""full"":""fullPath 2""}]");
            }
        }
    }
}
