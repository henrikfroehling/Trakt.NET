namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new NetworkArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetworks = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktNetworks.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new NetworkArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetworks = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
                var items = traktNetworks.ToArray();

                items[0].Should().NotBeNull();
                items[0].Name.Should().Be("ABC(US)");

                items[1].Should().NotBeNull();
                items[1].Name.Should().Be("The CW");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new NetworkArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetworks = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
                var items = traktNetworks.ToArray();

                items[0].Should().NotBeNull();
                items[0].Name.Should().Be("ABC(US)");

                items[1].Should().NotBeNull();
                items[1].Name.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new NetworkArrayJsonReader();

            var traktNetworks = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktNetworks.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new NetworkArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktNetworks = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktNetworks.Should().BeNull();
            }
        }
    }
}
