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
    public partial class ImageObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_ImageObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ImageObjectJsonWriter();
            ITraktImage traktImage = new TraktImage();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktImage);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktImage traktImage = new TraktImage
            {
                Full = "fullPath"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ImageObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktImage);
                stringWriter.ToString().Should().Be(@"{""full"":""fullPath""}");
            }
        }
    }
}
