namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class NetworkArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktNetwork>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktNetworks = await jsonReader.ReadArrayAsync(stream);
                traktNetworks.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktNetwork>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktNetworks = await jsonReader.ReadArrayAsync(stream);

                traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
                var items = traktNetworks.ToArray();

                items[0].Should().NotBeNull();
                items[0].Name.Should().Be("ABC(US)");

                items[1].Should().NotBeNull();
                items[1].Name.Should().Be("The CW");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new ArrayJsonReader<ITraktNetwork>();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktNetworks = await jsonReader.ReadArrayAsync(stream);

                traktNetworks.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
                var items = traktNetworks.ToArray();

                items[0].Should().NotBeNull();
                items[0].Name.Should().Be("ABC(US)");

                items[1].Should().NotBeNull();
                items[1].Name.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktNetwork>();
            Func<Task<IEnumerable<ITraktNetwork>>> traktNetworks = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktNetworks.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktNetwork>();

            using (var stream = string.Empty.ToStream())
            {
                var traktNetworks = await jsonReader.ReadArrayAsync(stream);
                traktNetworks.Should().BeNull();
            }
        }
    }
}
