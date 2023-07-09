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
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().Be(5);
            traktPopularList.CommentCount.Should().Be(5);

            traktPopularList.List.Should().NotBeNull();
            traktPopularList.List.Name.Should().Be("Incredible Thoughts");
            traktPopularList.List.Description.Should().Be("How could my brain conceive them?");
            traktPopularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktPopularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktPopularList.List.Type.Should().Be(TraktListType.Personal);
            traktPopularList.List.DisplayNumbers.Should().BeTrue();
            traktPopularList.List.AllowComments.Should().BeTrue();
            traktPopularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktPopularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktPopularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.ItemCount.Should().Be(50);
            traktPopularList.List.CommentCount.Should().Be(10);
            traktPopularList.List.Likes.Should().Be(99);

            traktPopularList.List.Ids.Should().NotBeNull();
            traktPopularList.List.Ids.Trakt.Should().Be(1337);
            traktPopularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktPopularList.List.User.Should().NotBeNull();
            traktPopularList.List.User.Username.Should().Be("justin");
            traktPopularList.List.User.IsPrivate.Should().BeFalse();
            traktPopularList.List.User.Name.Should().Be("Justin Nemeth");
            traktPopularList.List.User.IsVIP.Should().BeTrue();
            traktPopularList.List.User.IsVIP_EP.Should().BeFalse();
            traktPopularList.List.User.Ids.Should().NotBeNull();
            traktPopularList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().BeNull();
            traktPopularList.CommentCount.Should().Be(5);

            traktPopularList.List.Should().NotBeNull();
            traktPopularList.List.Name.Should().Be("Incredible Thoughts");
            traktPopularList.List.Description.Should().Be("How could my brain conceive them?");
            traktPopularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktPopularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktPopularList.List.Type.Should().Be(TraktListType.Personal);
            traktPopularList.List.DisplayNumbers.Should().BeTrue();
            traktPopularList.List.AllowComments.Should().BeTrue();
            traktPopularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktPopularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktPopularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.ItemCount.Should().Be(50);
            traktPopularList.List.CommentCount.Should().Be(10);
            traktPopularList.List.Likes.Should().Be(99);

            traktPopularList.List.Ids.Should().NotBeNull();
            traktPopularList.List.Ids.Trakt.Should().Be(1337);
            traktPopularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktPopularList.List.User.Should().NotBeNull();
            traktPopularList.List.User.Username.Should().Be("justin");
            traktPopularList.List.User.IsPrivate.Should().BeFalse();
            traktPopularList.List.User.Name.Should().Be("Justin Nemeth");
            traktPopularList.List.User.IsVIP.Should().BeTrue();
            traktPopularList.List.User.IsVIP_EP.Should().BeFalse();
            traktPopularList.List.User.Ids.Should().NotBeNull();
            traktPopularList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().Be(5);
            traktPopularList.CommentCount.Should().BeNull();

            traktPopularList.List.Should().NotBeNull();
            traktPopularList.List.Name.Should().Be("Incredible Thoughts");
            traktPopularList.List.Description.Should().Be("How could my brain conceive them?");
            traktPopularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktPopularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktPopularList.List.Type.Should().Be(TraktListType.Personal);
            traktPopularList.List.DisplayNumbers.Should().BeTrue();
            traktPopularList.List.AllowComments.Should().BeTrue();
            traktPopularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktPopularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktPopularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.ItemCount.Should().Be(50);
            traktPopularList.List.CommentCount.Should().Be(10);
            traktPopularList.List.Likes.Should().Be(99);

            traktPopularList.List.Ids.Should().NotBeNull();
            traktPopularList.List.Ids.Trakt.Should().Be(1337);
            traktPopularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktPopularList.List.User.Should().NotBeNull();
            traktPopularList.List.User.Username.Should().Be("justin");
            traktPopularList.List.User.IsPrivate.Should().BeFalse();
            traktPopularList.List.User.Name.Should().Be("Justin Nemeth");
            traktPopularList.List.User.IsVIP.Should().BeTrue();
            traktPopularList.List.User.IsVIP_EP.Should().BeFalse();
            traktPopularList.List.User.Ids.Should().NotBeNull();
            traktPopularList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().Be(5);
            traktPopularList.CommentCount.Should().Be(5);

            traktPopularList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().BeNull();
            traktPopularList.CommentCount.Should().Be(5);

            traktPopularList.List.Should().NotBeNull();
            traktPopularList.List.Name.Should().Be("Incredible Thoughts");
            traktPopularList.List.Description.Should().Be("How could my brain conceive them?");
            traktPopularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktPopularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktPopularList.List.Type.Should().Be(TraktListType.Personal);
            traktPopularList.List.DisplayNumbers.Should().BeTrue();
            traktPopularList.List.AllowComments.Should().BeTrue();
            traktPopularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktPopularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktPopularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.ItemCount.Should().Be(50);
            traktPopularList.List.CommentCount.Should().Be(10);
            traktPopularList.List.Likes.Should().Be(99);

            traktPopularList.List.Ids.Should().NotBeNull();
            traktPopularList.List.Ids.Trakt.Should().Be(1337);
            traktPopularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktPopularList.List.User.Should().NotBeNull();
            traktPopularList.List.User.Username.Should().Be("justin");
            traktPopularList.List.User.IsPrivate.Should().BeFalse();
            traktPopularList.List.User.Name.Should().Be("Justin Nemeth");
            traktPopularList.List.User.IsVIP.Should().BeTrue();
            traktPopularList.List.User.IsVIP_EP.Should().BeFalse();
            traktPopularList.List.User.Ids.Should().NotBeNull();
            traktPopularList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().Be(5);
            traktPopularList.CommentCount.Should().BeNull();

            traktPopularList.List.Should().NotBeNull();
            traktPopularList.List.Name.Should().Be("Incredible Thoughts");
            traktPopularList.List.Description.Should().Be("How could my brain conceive them?");
            traktPopularList.List.Privacy.Should().Be(TraktListPrivacy.Public);
            traktPopularList.List.ShareLink.Should().Be("https://trakt.tv/lists/1337");
            traktPopularList.List.Type.Should().Be(TraktListType.Personal);
            traktPopularList.List.DisplayNumbers.Should().BeTrue();
            traktPopularList.List.AllowComments.Should().BeTrue();
            traktPopularList.List.SortBy.Should().Be(TraktSortBy.Rank);
            traktPopularList.List.SortHow.Should().Be(TraktSortHow.Ascending);
            traktPopularList.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktPopularList.List.ItemCount.Should().Be(50);
            traktPopularList.List.CommentCount.Should().Be(10);
            traktPopularList.List.Likes.Should().Be(99);

            traktPopularList.List.Ids.Should().NotBeNull();
            traktPopularList.List.Ids.Trakt.Should().Be(1337);
            traktPopularList.List.Ids.Slug.Should().Be("incredible-thoughts");

            traktPopularList.List.User.Should().NotBeNull();
            traktPopularList.List.User.Username.Should().Be("justin");
            traktPopularList.List.User.IsPrivate.Should().BeFalse();
            traktPopularList.List.User.Name.Should().Be("Justin Nemeth");
            traktPopularList.List.User.IsVIP.Should().BeTrue();
            traktPopularList.List.User.IsVIP_EP.Should().BeFalse();
            traktPopularList.List.User.Ids.Should().NotBeNull();
            traktPopularList.List.User.Ids.Slug.Should().Be("justin");
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().Be(5);
            traktPopularList.CommentCount.Should().Be(5);

            traktPopularList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPopularList.Should().NotBeNull();

            traktPopularList.LikeCount.Should().BeNull();
            traktPopularList.CommentCount.Should().BeNull();
            traktPopularList.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PopularListObjectJsonReader();
            Func<Task<ITraktPopularList>> traktPopularList = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktPopularList.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PopularListObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PopularListObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktPopularList = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktPopularList.Should().BeNull();
        }
    }
}
