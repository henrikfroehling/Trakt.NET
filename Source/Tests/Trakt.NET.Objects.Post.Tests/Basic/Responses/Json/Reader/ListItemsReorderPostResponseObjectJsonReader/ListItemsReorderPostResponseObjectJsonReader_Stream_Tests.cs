namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Basic.Responses.JsonReader")]
    public partial class ListItemsReorderPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
                listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().Be(6);
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPostResponse.Should().NotBeNull();
                listItemsReorderPostResponse.Updated.Should().BeNull();
                listItemsReorderPostResponse.SkippedIds.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            Func<Task<ITraktListItemsReorderPostResponse>> listItemsReorderPostResponse = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await listItemsReorderPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(stream);
                listItemsReorderPostResponse.Should().BeNull();
            }
        }
    }
}
