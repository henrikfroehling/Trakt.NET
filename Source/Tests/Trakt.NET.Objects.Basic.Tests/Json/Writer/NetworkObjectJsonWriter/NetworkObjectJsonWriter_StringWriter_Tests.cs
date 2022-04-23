namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new NetworkObjectJsonWriter();
            ITraktNetwork traktNetwork = new TraktNetwork();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktNetwork);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Name = "network"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new NetworkObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktNetwork);
                json.Should().Be(@"{""name"":""network""}");
            }
        }
    }
}
