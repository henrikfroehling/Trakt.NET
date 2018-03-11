namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_NetworkObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new NetworkObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktNetwork));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Network = "network"
            };

            var traktJsonWriter = new NetworkObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetwork);
            json.Should().Be(@"{""network"":""network""}");
        }
    }
}
