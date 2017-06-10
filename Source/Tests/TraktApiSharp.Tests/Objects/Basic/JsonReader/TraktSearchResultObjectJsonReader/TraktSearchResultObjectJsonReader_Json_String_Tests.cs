namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktSearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(default(string));
            traktSearchResultItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSearchResultObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktSearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktSearchResultItem.Should().BeNull();
        }
    }
}
