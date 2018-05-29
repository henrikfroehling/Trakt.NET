namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_NetworkArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            IEnumerable<ITraktNetwork> traktNetworks = new List<TraktNetwork>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktNetworks);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<TraktNetwork>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktNetworks);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<ITraktNetwork>
            {
                new TraktNetwork
                {
                    Network = "network 1"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktNetworks);
                json.Should().Be(@"[{""network"":""network 1""}]");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<ITraktNetwork>
            {
                new TraktNetwork
                {
                    Network = "network 1"
                },
                new TraktNetwork
                {
                    Network = "network 2"
                },
                new TraktNetwork
                {
                    Network = "network 3"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktNetworks);
                json.Should().Be(@"[{""network"":""network 1""}," +
                                 @"{""network"":""network 2""}," +
                                 @"{""network"":""network 3""}]");
            }
        }
    }
}
