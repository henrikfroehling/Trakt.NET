namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktSearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktSearchResultObjectJsonReader();

            var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSearchResultItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktSearchResultObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSearchResultItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSearchResultItem.Should().BeNull();
            }
        }
    }
}
