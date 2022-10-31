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
    public partial class ImageArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktImage> traktImage = new List<TraktImage>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktImage);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktImage> traktImage = new List<ITraktImage>
            {
                new TraktImage
                {
                    Full = "fullPath 1"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktImage);
            json.Should().Be(@"[{""full"":""fullPath 1""}]");
        }

        [Fact]
        public async Task Test_ImageArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktImage>();
            string json = await traktJsonWriter.WriteArrayAsync(traktImage);
            json.Should().Be(@"[{""full"":""fullPath 1""},{""full"":""fullPath 2""}]");
        }
    }
}
