namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
    public partial class ListObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().BeNull();

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().BeNull();

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_15()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_15);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_16()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_16);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_17()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_17);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_18()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_18);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_19()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_19);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_20()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_20);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_21()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_21);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_22()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_22);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_23()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_23);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_24()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_24);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_25()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_25);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_26()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_26);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().Be(2);
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_27()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_27);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Incomplete_28()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_28);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_9()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_9);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_10()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_10);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_11()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_11);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_12()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_12);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().BeNull();

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_13()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_13);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().BeNull();

            traktList.User.Should().NotBeNull();
            traktList.User.Username.Should().Be("sean");
            traktList.User.IsPrivate.Should().BeFalse();
            traktList.User.Name.Should().Be("Sean Rudford");
            traktList.User.IsVIP.Should().BeTrue();
            traktList.User.IsVIP_EP.Should().BeFalse();
            traktList.User.Ids.Should().NotBeNull();
            traktList.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_14()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_14);

            traktList.Should().NotBeNull();
            traktList.Name.Should().Be("Star Wars in machete order");
            traktList.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktList.Privacy.Should().Be(TraktAccessScope.Public);
            traktList.DisplayNumbers.Should().BeTrue();
            traktList.AllowComments.Should().BeFalse();
            traktList.SortBy.Should().Be("rank");
            traktList.SortHow.Should().Be("asc");
            traktList.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktList.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktList.ItemCount.Should().Be(5);
            traktList.CommentCount.Should().Be(1);
            traktList.Likes.Should().Be(2);

            traktList.Ids.Should().NotBeNull();
            traktList.Ids.Trakt.Should().Be(55);
            traktList.Ids.Slug.Should().Be("star-wars-in-machete-order");

            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Not_Valid_15()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_15);

            traktList.Should().NotBeNull();
            traktList.Name.Should().BeNull();
            traktList.Description.Should().BeNull();
            traktList.Privacy.Should().BeNull();
            traktList.DisplayNumbers.Should().BeNull();
            traktList.AllowComments.Should().BeNull();
            traktList.SortBy.Should().BeNull();
            traktList.SortHow.Should().BeNull();
            traktList.CreatedAt.Should().BeNull();
            traktList.UpdatedAt.Should().BeNull();
            traktList.ItemCount.Should().BeNull();
            traktList.CommentCount.Should().BeNull();
            traktList.Likes.Should().BeNull();
            traktList.Ids.Should().BeNull();
            traktList.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ListObjectJsonReader();
            Func<Task<ITraktList>> traktList = () => jsonReader.ReadObjectAsync(default(string));
            await traktList.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ListObjectJsonReader();

            var traktList = await jsonReader.ReadObjectAsync(string.Empty);
            traktList.Should().BeNull();
        }
    }
}
