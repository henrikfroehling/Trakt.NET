namespace TraktNet.Objects.Post.Tests.Syncs.Lists.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Lists;
    using TraktNet.Objects.Post.Syncs.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Lists.Implementations")]
    public class TraktUpdateListPost_Tests
    {
        [Fact]
        public void Test_TraktUpdateListPost_Default_Constructor()
        {
            var updateListPost = new TraktUpdateListPost();

            updateListPost.Description.Should().BeNull();
            updateListPost.SortBy.Should().BeNull();
            updateListPost.SortHow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUpdateListPost_From_Json()
        {
            var jsonReader = new UpdateListPostObjectJsonReader();
            var updateListPost = await jsonReader.ReadObjectAsync(JSON) as TraktUpdateListPost;

            updateListPost.Should().NotBeNull();
            updateListPost.Description.Should().Be("Updated description");
            updateListPost.SortBy.Should().Be(TraktSortBy.Rank);
            updateListPost.SortHow.Should().Be(TraktSortHow.Descending);
        }

        [Fact]
        public void Test_TraktUpdateListPost_Validate()
        {
            ITraktUpdateListPost updateListPost = new TraktUpdateListPost();

            // description = null, sortBy = null, sortHow = null
            Action act = () => updateListPost.Validate();
            _ = act.Should().Throw<TraktPostValidationException>();

            // description = empty, sortBy = null, sortHow = null
            updateListPost.Description = string.Empty;
            _ = act.Should().Throw<TraktPostValidationException>();

            // description = not empty, sortBy = null, sortHow = null
            updateListPost.Description = "description";
            _ = act.Should().NotThrow();

            // description = null, sortBy = unspecified, sortHow = null
            updateListPost.Description = null;
            updateListPost.SortBy = TraktSortBy.Unspecified;
            _ = act.Should().Throw<TraktPostValidationException>();

            // description = null, sortBy = has value, sortHow = null
            updateListPost.SortBy = TraktSortBy.Rank;
            _ = act.Should().NotThrow();

            // description = null, sortBy = null, sortHow = unspecified
            updateListPost.SortBy = null;
            updateListPost.SortHow = TraktSortHow.Unspecified;
            _ = act.Should().Throw<TraktPostValidationException>();

            // description = null, sortBy = null, sortHow = has value
            updateListPost.SortHow = TraktSortHow.Descending;
            _ = act.Should().NotThrow();
        }

        private const string JSON =
            @"{
                ""description"": ""Updated description"",
                ""sort_by"": ""rank"",
                ""sort_how"": ""desc""
              }";
    }
}
