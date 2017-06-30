namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktSearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktSearchResultItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSearchResultItem = await jsonReader.ReadObjectAsync(stream);
                traktSearchResultItem.Should().BeNull();
            }
        }
    }
}
