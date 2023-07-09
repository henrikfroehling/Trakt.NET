namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
    public partial class TrendingOrPopularListObjectJsonReader_Tests_Json_Data
    {
        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().Be(5);
            traktTrendingList.CommentCount.Should().Be(5);

            traktTrendingList.List.Should().NotBeNull();
            traktTrendingList.List.Name.Should().Be("Incredible Thoughts");
            traktTrendingList.List.Description.Should().Be("How could my brain conceive them?");
            traktTrendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktTrendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktTrendingList.List.Type.Should().Be(TraktListType.Personal);
            traktTrendingList.List.DisplayNumbers.Should().BeTrue();
            traktTrendingList.List.AllowComments.Should().BeTrue();
            traktTrendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktTrendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktTrendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.ItemCount.Should().Be(50);
            traktTrendingList.List.CommentCount.Should().Be(10);
            traktTrendingList.List.Likes.Should().Be(99);

            traktTrendingList.List.Ids.Should().NotBeNull();
            traktTrendingList.List.Ids.Trakt.Should().Be(1337);
            traktTrendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktTrendingList.List.User.Should().NotBeNull();
            traktTrendingList.List.User.Username.Should().Be("justin");
            traktTrendingList.List.User.IsPrivate.Should().BeFalse();
            traktTrendingList.List.User.Name.Should().Be("Justin Nemeth");
            traktTrendingList.List.User.IsVIP.Should().BeTrue();
            traktTrendingList.List.User.IsVIP_EP.Should().BeFalse();
            traktTrendingList.List.User.Ids.Should().NotBeNull();
            traktTrendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().BeNull();
            traktTrendingList.CommentCount.Should().Be(5);

            traktTrendingList.List.Should().NotBeNull();
            traktTrendingList.List.Name.Should().Be("Incredible Thoughts");
            traktTrendingList.List.Description.Should().Be("How could my brain conceive them?");
            traktTrendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktTrendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktTrendingList.List.Type.Should().Be(TraktListType.Personal);
            traktTrendingList.List.DisplayNumbers.Should().BeTrue();
            traktTrendingList.List.AllowComments.Should().BeTrue();
            traktTrendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktTrendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktTrendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.ItemCount.Should().Be(50);
            traktTrendingList.List.CommentCount.Should().Be(10);
            traktTrendingList.List.Likes.Should().Be(99);

            traktTrendingList.List.Ids.Should().NotBeNull();
            traktTrendingList.List.Ids.Trakt.Should().Be(1337);
            traktTrendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktTrendingList.List.User.Should().NotBeNull();
            traktTrendingList.List.User.Username.Should().Be("justin");
            traktTrendingList.List.User.IsPrivate.Should().BeFalse();
            traktTrendingList.List.User.Name.Should().Be("Justin Nemeth");
            traktTrendingList.List.User.IsVIP.Should().BeTrue();
            traktTrendingList.List.User.IsVIP_EP.Should().BeFalse();
            traktTrendingList.List.User.Ids.Should().NotBeNull();
            traktTrendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().Be(5);
            traktTrendingList.CommentCount.Should().BeNull();

            traktTrendingList.List.Should().NotBeNull();
            traktTrendingList.List.Name.Should().Be("Incredible Thoughts");
            traktTrendingList.List.Description.Should().Be("How could my brain conceive them?");
            traktTrendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktTrendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktTrendingList.List.Type.Should().Be(TraktListType.Personal);
            traktTrendingList.List.DisplayNumbers.Should().BeTrue();
            traktTrendingList.List.AllowComments.Should().BeTrue();
            traktTrendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktTrendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktTrendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.ItemCount.Should().Be(50);
            traktTrendingList.List.CommentCount.Should().Be(10);
            traktTrendingList.List.Likes.Should().Be(99);

            traktTrendingList.List.Ids.Should().NotBeNull();
            traktTrendingList.List.Ids.Trakt.Should().Be(1337);
            traktTrendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktTrendingList.List.User.Should().NotBeNull();
            traktTrendingList.List.User.Username.Should().Be("justin");
            traktTrendingList.List.User.IsPrivate.Should().BeFalse();
            traktTrendingList.List.User.Name.Should().Be("Justin Nemeth");
            traktTrendingList.List.User.IsVIP.Should().BeTrue();
            traktTrendingList.List.User.IsVIP_EP.Should().BeFalse();
            traktTrendingList.List.User.Ids.Should().NotBeNull();
            traktTrendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().Be(5);
            traktTrendingList.CommentCount.Should().Be(5);

            traktTrendingList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().BeNull();
            traktTrendingList.CommentCount.Should().Be(5);

            traktTrendingList.List.Should().NotBeNull();
            traktTrendingList.List.Name.Should().Be("Incredible Thoughts");
            traktTrendingList.List.Description.Should().Be("How could my brain conceive them?");
            traktTrendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktTrendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktTrendingList.List.Type.Should().Be(TraktListType.Personal);
            traktTrendingList.List.DisplayNumbers.Should().BeTrue();
            traktTrendingList.List.AllowComments.Should().BeTrue();
            traktTrendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktTrendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktTrendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.ItemCount.Should().Be(50);
            traktTrendingList.List.CommentCount.Should().Be(10);
            traktTrendingList.List.Likes.Should().Be(99);

            traktTrendingList.List.Ids.Should().NotBeNull();
            traktTrendingList.List.Ids.Trakt.Should().Be(1337);
            traktTrendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktTrendingList.List.User.Should().NotBeNull();
            traktTrendingList.List.User.Username.Should().Be("justin");
            traktTrendingList.List.User.IsPrivate.Should().BeFalse();
            traktTrendingList.List.User.Name.Should().Be("Justin Nemeth");
            traktTrendingList.List.User.IsVIP.Should().BeTrue();
            traktTrendingList.List.User.IsVIP_EP.Should().BeFalse();
            traktTrendingList.List.User.Ids.Should().NotBeNull();
            traktTrendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().Be(5);
            traktTrendingList.CommentCount.Should().BeNull();

            traktTrendingList.List.Should().NotBeNull();
            traktTrendingList.List.Name.Should().Be("Incredible Thoughts");
            traktTrendingList.List.Description.Should().Be("How could my brain conceive them?");
            traktTrendingList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktTrendingList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktTrendingList.List.Type.Should().Be(TraktListType.Personal);
            traktTrendingList.List.DisplayNumbers.Should().BeTrue();
            traktTrendingList.List.AllowComments.Should().BeTrue();
            traktTrendingList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktTrendingList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktTrendingList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktTrendingList.List.ItemCount.Should().Be(50);
            traktTrendingList.List.CommentCount.Should().Be(10);
            traktTrendingList.List.Likes.Should().Be(99);

            traktTrendingList.List.Ids.Should().NotBeNull();
            traktTrendingList.List.Ids.Trakt.Should().Be(1337);
            traktTrendingList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktTrendingList.List.User.Should().NotBeNull();
            traktTrendingList.List.User.Username.Should().Be("justin");
            traktTrendingList.List.User.IsPrivate.Should().BeFalse();
            traktTrendingList.List.User.Name.Should().Be("Justin Nemeth");
            traktTrendingList.List.User.IsVIP.Should().BeTrue();
            traktTrendingList.List.User.IsVIP_EP.Should().BeFalse();
            traktTrendingList.List.User.Ids.Should().NotBeNull();
            traktTrendingList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().Be(5);
            traktTrendingList.CommentCount.Should().Be(5);

            traktTrendingList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktTrendingList.Should().NotBeNull();

            traktTrendingList.LikeCount.Should().BeNull();
            traktTrendingList.CommentCount.Should().BeNull();
            traktTrendingList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();
            Func<Task<ITraktTrendingList>> traktTrendingList = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktTrendingList.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_TrendingListObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TrendingListObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktTrendingList = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktTrendingList.Should().BeNull();
        }
    }
}
