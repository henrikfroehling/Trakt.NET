namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_COMPLETE);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_1);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_2);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_3);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().BeNull();

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_4);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.List.Should().BeNull();

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_5);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().BeNull();

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_INCOMPLETE_6);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_1);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_2);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.List.Should().NotBeNull();
            traktUserLikeItem.List.Name.Should().Be("Star Wars in machete order");
            traktUserLikeItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktUserLikeItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktUserLikeItem.List.DisplayNumbers.Should().BeTrue();
            traktUserLikeItem.List.AllowComments.Should().BeFalse();
            traktUserLikeItem.List.SortBy.Should().Be("rank");
            traktUserLikeItem.List.SortHow.Should().Be("asc");
            traktUserLikeItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktUserLikeItem.List.ItemCount.Should().Be(5);
            traktUserLikeItem.List.CommentCount.Should().Be(1);
            traktUserLikeItem.List.Likes.Should().Be(2);
            traktUserLikeItem.List.Ids.Should().NotBeNull();
            traktUserLikeItem.List.Ids.Trakt.Should().Be(55);
            traktUserLikeItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktUserLikeItem.List.User.Should().NotBeNull();
            traktUserLikeItem.List.User.Username.Should().Be("sean");
            traktUserLikeItem.List.User.IsPrivate.Should().BeFalse();
            traktUserLikeItem.List.User.Name.Should().Be("Sean Rudford");
            traktUserLikeItem.List.User.IsVIP.Should().BeTrue();
            traktUserLikeItem.List.User.IsVIP_EP.Should().BeFalse();
            traktUserLikeItem.List.User.Ids.Should().NotBeNull();
            traktUserLikeItem.List.User.Ids.Slug.Should().Be("sean");

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_3);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.List);
            traktUserLikeItem.List.Should().BeNull();

            traktUserLikeItem.Comment.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_List_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_LIST_JSON_NOT_VALID_4);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.List.Should().BeNull();
            traktUserLikeItem.Comment.Should().BeNull();
        }
    }
}
