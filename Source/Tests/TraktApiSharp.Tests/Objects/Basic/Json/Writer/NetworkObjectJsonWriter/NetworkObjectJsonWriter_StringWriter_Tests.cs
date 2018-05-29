namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_NetworkObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new NetworkObjectJsonWriter();
            ITraktNetwork traktNetwork = new TraktNetwork();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktNetwork);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Network = "network"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new NetworkObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktNetwork);
                json.Should().Be(@"{""network"":""network""}");
            }
        }
    }
}
