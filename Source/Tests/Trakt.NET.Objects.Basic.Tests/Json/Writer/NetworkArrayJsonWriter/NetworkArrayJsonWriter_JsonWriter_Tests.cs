namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
            IEnumerable<ITraktNetwork> traktNetworks = new List<TraktNetwork>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktNetworks);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<TraktNetwork>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktNetworks);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktNetwork> traktNetworks = new List<ITraktNetwork>
            {
                new TraktNetwork
                {
                    Name = "network 1"
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktNetworks);
                stringWriter.ToString().Should().Be(@"[{""name"":""network 1""}]");
            }
        }

        [Fact]
        public async Task Test_NetworkArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktNetwork>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktNetworks);
                stringWriter.ToString().Should().Be(@"[{""name"":""network 1""}," +
                                                    @"{""name"":""network 2""}," +
                                                    @"{""name"":""network 3""}]");
            }
        }
    }
}
