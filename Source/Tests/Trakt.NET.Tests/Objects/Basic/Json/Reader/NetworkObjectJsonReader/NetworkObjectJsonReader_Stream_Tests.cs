namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(stream);

                traktNetwork.Should().NotBeNull();
                traktNetwork.Name.Should().Be("ABC(US)");
            }
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(stream);

                traktNetwork.Should().NotBeNull();
                traktNetwork.Name.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            var traktNetwork = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktNetwork.Should().BeNull();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new NetworkObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktNetwork = await traktJsonReader.ReadObjectAsync(stream);
                traktNetwork.Should().BeNull();
            }
        }
    }
}
