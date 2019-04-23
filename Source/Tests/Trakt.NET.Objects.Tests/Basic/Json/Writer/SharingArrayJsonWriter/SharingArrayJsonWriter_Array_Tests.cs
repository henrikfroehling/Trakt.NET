namespace TraktNet.Objects.Tests.Basic.Json.Writer
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
    public partial class SharingArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_SharingArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<TraktSharing>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSharing);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSharing);
            json.Should().Be(@"[{""twitter"":true,""google"":true," +
                             @"""tumblr"":true,""medium"":true,""slack"":true}]");
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                },
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSharing);
            json.Should().Be(@"[{""twitter"":true,""google"":true," +
                             @"""tumblr"":true,""medium"":true,""slack"":true}," +
                             @"{""twitter"":true,""google"":true," +
                             @"""tumblr"":true,""medium"":true,""slack"":true}]");
        }
    }
}
