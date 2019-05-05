namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktNetworks.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktNetworks.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("ABC(US)");

            items[1].Should().NotBeNull();
            items[1].Name.Should().Be("The CW");
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Json_String_Not_Valid()
        {
            var jsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await jsonReader.ReadArrayAsync(JSON_NOT_VALID);

            traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var items = traktNetworks.ToArray();

            items[0].Should().NotBeNull();
            items[0].Name.Should().Be("ABC(US)");

            items[1].Should().NotBeNull();
            items[1].Name.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await jsonReader.ReadArrayAsync(default(string));
            traktNetworks.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await jsonReader.ReadArrayAsync(string.Empty);
            traktNetworks.Should().BeNull();
        }
    }
}
