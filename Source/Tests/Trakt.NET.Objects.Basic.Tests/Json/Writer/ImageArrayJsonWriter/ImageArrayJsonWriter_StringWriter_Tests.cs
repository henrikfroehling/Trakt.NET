namespace TraktNet.Objects.Basic.Tests.Json.Writer
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
    public partial class ImageArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            IEnumerable<ITraktImage> traktImage = new List<TraktImage>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktImage);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktImage> traktImage = new List<TraktImage>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktImage> traktImage = new List<ITraktImage>
            {
                new TraktImage
                {
                    Full = "fullPath 1"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be(@"[{""full"":""fullPath 1""}]");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_StringWriter_Complete()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktImage);
                json.Should().Be(@"[{""full"":""fullPath 1""},{""full"":""fullPath 2""}]");
            }
        }
    }
}
