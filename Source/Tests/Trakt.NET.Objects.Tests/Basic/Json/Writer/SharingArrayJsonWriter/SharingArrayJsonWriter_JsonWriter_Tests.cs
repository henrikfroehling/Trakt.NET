namespace TraktNet.Objects.Tests.Basic.Json.Writer
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
    public partial class SharingArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_SharingArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            IEnumerable<ITraktSharing> traktSharing = new List<TraktSharing>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktSharing);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<TraktSharing>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Facebook = true,
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"[{""facebook"":true,""twitter"":true,""google"":true," +
                                                    @"""tumblr"":true,""medium"":true,""slack"":true}]");
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Facebook = true,
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                },
                new TraktSharing
                {
                    Facebook = true,
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"[{""facebook"":true,""twitter"":true,""google"":true," +
                                                    @"""tumblr"":true,""medium"":true,""slack"":true}," +
                                                    @"{""facebook"":true,""twitter"":true,""google"":true," +
                                                    @"""tumblr"":true,""medium"":true,""slack"":true}]");
            }
        }
    }
}
