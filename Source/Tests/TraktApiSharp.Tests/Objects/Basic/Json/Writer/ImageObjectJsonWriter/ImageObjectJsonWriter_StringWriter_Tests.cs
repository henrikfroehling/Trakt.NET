namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class ImageObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_ImageObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ImageObjectJsonWriter();
            ITraktImage traktImage = new TraktImage();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktImage);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktImage traktImage = new TraktImage
            {
                Full = "fullPath"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ImageObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktImage);
                json.Should().Be(@"{""full"":""fullPath""}");
            }
        }
    }
}
