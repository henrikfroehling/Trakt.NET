namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Writer;
    using Xunit;

    [Category("Objects.Post.Basic.Responses.JsonWriter")]
    public partial class ListItemsReorderPostResponseObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), listItemsReorderPostResponse);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Only_Updated_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, listItemsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""updated"":6}");
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Only_SkippedIds_Property()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, listItemsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""skipped_ids"":[2]}");
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktListItemsReorderPostResponse listItemsReorderPostResponse = new TraktListItemsReorderPostResponse
            {
                Updated = 6,
                SkippedIds = new List<uint> { 2 }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ListItemsReorderPostResponseObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, listItemsReorderPostResponse);
                stringWriter.ToString().Should().Be(@"{""updated"":6,""skipped_ids"":[2]}");
            }
        }
    }
}
