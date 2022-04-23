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

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<TraktNetwork>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            string json = await traktJsonWriter.WriteArrayAsync(traktNetworks);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<ITraktNetwork>
            {
                new TraktNetwork
                {
                    Name = "network 1"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            string json = await traktJsonWriter.WriteArrayAsync(traktNetworks);
            json.Should().Be(@"[{""name"":""network 1""}]");
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<ITraktNetwork>
            {
                new TraktNetwork
                {
                    Name = "network 1"
                },
                new TraktNetwork
                {
                    Name = "network 2"
                },
                new TraktNetwork
                {
                    Name = "network 3"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            string json = await traktJsonWriter.WriteArrayAsync(traktNetworks);
            json.Should().Be(@"[{""name"":""network 1""}," +
                             @"{""name"":""network 2""}," +
                             @"{""name"":""network 3""}]");
        }
    }
}
